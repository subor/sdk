using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
using Ruyi.SDK.StorageLayer;
using System;
using System.Net;
using System.Net.Sockets;
using Thrift.Protocol;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// The main client for accessing Ruyi Net Services
    /// </summary>
    public class RuyiNetClient : IDisposable
    {
        private const int MAX_PLAYERS = 4;

        /// <summary>
        /// Initialise the RUYI net client and switch to the game context.
        /// </summary>
        /// <param name="appId">The App ID of the game to initialise for.</param>
        /// <param name="appSecret">The App secret of the game. NOTE: This is a password and should be treated as such.</param>
        /// <param name="onInitialised">The function to call whe initialisation completes.</param>
        public void Initialise(string appId, string appSecret, Action onInitialised)
        {
            if (Initialised)
            {
                onInitialised?.Invoke();

                return;
            }

            AppId = appId;
            AppSecret = appSecret;

            EnqueueTask(() =>
            {
                var hostString = Dns.GetHostName();
                
                IPHostEntry hostInfo = Dns.GetHostEntry(hostString);
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        RemoteIpAddress = ip.ToString();
                    }
                }

                for (int i = 0; i < MAX_PLAYERS; ++i)
                {
                    CurrentPlayers[i] = null;
                    var jsonResponse = BCService.Identity_SwitchToSingletonChildProfile(AppId, true, i);
                    var childProfile = JsonConvert.DeserializeObject<RuyiNetSwitchToChildProfileResponse>(jsonResponse);
                    if (childProfile.status != 200)
                    {
                        continue;
                    }

                    var profileId = childProfile.data.parentProfileId;
                    var profileName = childProfile.data.playerName;

                    NewUser = childProfile.data.newUser;

                    var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                    jsonResponse = BCService.Script_RunParentScript("GetProfile", JsonConvert.SerializeObject(payload), "RUYI", i);

                    var profileData = JsonConvert.DeserializeObject<RuyiNetGetProfileResponse>(jsonResponse);
                    if (profileData.status != 200 ||
                        profileData.data.success == false)
                    {
                        continue;
                    }

                    CurrentPlayers[i] = profileData.data.response;
                }

                var response = new RuyiNetResponse()
                {
                    status = 200
                };

                return JsonConvert.SerializeObject(response);
            }, (RuyiNetResponse response) =>
            {
                Initialised = true;

                onInitialised?.Invoke();
            });
        }

        /// <summary>
        /// Update the tasks.
        /// </summary>
        public void Update()
        {
            mTaskQueue.Update();
        }

        /// <summary>
        /// Cleanup native resources before destruction.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Handles backing up data to the cloud.
        /// </summary>
        public RuyiNetCloudService CloudService { get; private set; }

        /// <summary>
        /// Provides operations for managing Friend Lists.
        /// </summary>
        public RuyiNetFriendService FriendService { get; private set; }

        /// <summary>
        /// Provides operations to retrieve leaderboard data and submit scores.
        /// </summary>
        public RuyiNetLeaderboardService LeaderboardService { get; private set; }

        /// <summary>
        /// Manages lobbies for network games.
        /// </summary>
        public RuyiNetLobbyService LobbyService { get; private set; }

        /// <summary>
        /// Allows players to gather together in a party.
        /// </summary>
        public RuyiNetPartyService PartyService { get; private set; }

        /// <summary>
        /// Allows users to upload files to their individual accounts
        /// </summary>
        public RuyiNetProfileService ProfileService { get; private set; }

        /// <summary>
        /// Handles pushing telemetry data to the cloud.
        /// </summary>
        public RuyiNetTelemetryService TelemetryService { get; private set; }

        /// <summary>
        /// Allows users to upload files to their individual accounts
        /// </summary>
        public RuyiNetUserFileService UserFileService { get; private set; }

        /// <summary>
        /// Allows users to upload videos to their individual accounts.
        /// </summary>
        public RuyiNetVideoService VideoService { get; private set; }

        /// <summary>
        /// The profile of the currently logged in player, if any.
        /// </summary>
        public RuyiNetProfile[] CurrentPlayers { get; private set; }

        /// <summary>
        /// Returns the index of the first active player available.
        /// </summary>
        public int ActivePlayerIndex
        {
            get
            {
                for (var i = 0; i < CurrentPlayers.Length; ++i)
                {
                    if (CurrentPlayers[i] != null)
                    {
                        return i;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Returns the first active player available.
        /// </summary>
        public RuyiNetProfile ActivePlayer
        {
            get
            {
                foreach (var i  in CurrentPlayers)
                {
                    if (i != null)
                    {
                        return i;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// The remote IP address that can be used to connect to this machine.
        /// </summary>
        public string RemoteIpAddress { get; private set; }

        /// <summary>
        /// Whether or not this player is a new user.
        /// </summary>
        public bool NewUser { get; private set; }

        /// <summary>
        /// Whether or not RuyiNet has been initialised.
        /// </summary>
        public bool Initialised { get; private set; }

        /// <summary>
        /// Returns TRUE while there are tasks in the queue.
        /// </summary>
        public bool IsWorking { get { return mTaskQueue.Work > 0; } }
        
        /// <summary>
        /// Cleanup native resources before destruction.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (BCService != null)
                {
                    for (int i = 0; i < MAX_PLAYERS; ++i)
                    {
                        if (CurrentPlayers[i] != null)
                        {
                            BCService.Script_RunParentScript("RUYI_Cleanup", "{}", "RUYI", i);
                            BCService.Identity_SwitchToParentProfile("RUYI", i);
                        }
                    }

                    BCService.Dispose();
                    BCService = null;
                }
            }
        }

        internal RuyiNetClient(TProtocol protocol, StorageLayerService.Client storageLayerService)
        {
            BCService = new BrainCloudService.Client(protocol);

            mTaskQueue = new RuyiNetTaskQueue();

            CloudService = new RuyiNetCloudService(this, storageLayerService);
            FriendService = new RuyiNetFriendService(this);
            LeaderboardService = new RuyiNetLeaderboardService(this);
            LobbyService = new RuyiNetLobbyService(this);
            PartyService = new RuyiNetPartyService(this);
            ProfileService = new RuyiNetProfileService(this);
            TelemetryService = new RuyiNetTelemetryService(this);
            UserFileService = new RuyiNetUserFileService(this);
            VideoService = new RuyiNetVideoService(this);

            CurrentPlayers = new RuyiNetProfile[MAX_PLAYERS];

            Initialised = false;
        }

        /// <summary>
        /// Queue up a request to the online service.
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="onExecute">The method to call when we execute the task.</param>
        /// <param name="callback">The callback to call when the task completes</param>
        internal void EnqueueTask<Response>(RuyiNetTask<Response>.ExecuteType onExecute, RuyiNetTask<Response>.CallbackType callback)
        {
            mTaskQueue.Enqueue(new RuyiNetTask<Response>(onExecute, callback));
        }

        /// <summary>
        /// Queue up a request to the online service that needs to be called on the RUYI platform level.
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="index">The index of user</param>
        /// <param name="onExecute">The method to call when we execute the task.</param>
        /// <param name="callback">The callback to call when the task completes</param>
        internal void EnqueuePlatformTask<Response>(int index, RuyiNetTask<Response>.ExecuteType onExecute, RuyiNetTask<Response>.CallbackType callback)
        {
            mTaskQueue.Enqueue(new RuyiNetPlatformTask<Response>(index, this, onExecute, callback));
        }

        /// <summary>
        /// The brainCloud client.
        /// FIXME, for temp to set it public, so it won't break the unit-test, will be set to internal
        /// after unit-test being fixed.
        /// </summary>
        internal BrainCloudService.Client BCService { get; private set; }

#pragma warning disable 649

        [Serializable]
        private class RuyiNetSwitchToChildProfileResponse
        {
            [Serializable]
            public class Data
            {

                public string parentProfileId;
                public string playerName;
                public bool newUser;
            }

            public Data data;
            public int status;
        }

#pragma warning restore 649

        internal string AppId { get; private set; }

        //  App secret is unused for now, but will become important for security when
        //  this is implemented properly.
        internal string AppSecret { get; private set; }

        private RuyiNetTaskQueue mTaskQueue;
    }


}

