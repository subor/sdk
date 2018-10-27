using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Manages lobbies for network games.
    /// </summary>
    public class RuyiNetLobbyService : RuyiNetService
    {
        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        public Task<RuyiNetLobby> CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType)
        {
            return CreateLobby(index, maxSlots, lobbyType, "{}");
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="customAttributes">JSON string of custom attributes to attach to this lobby.</param>
        public async Task<RuyiNetLobby> CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType, string customAttributes)
        {
            var payload = new RuyiNetLobbyCreateRequest()
            {
                appId = mClient.AppId,
                maxSlots = maxSlots,
                ranked = (lobbyType == RuyiNetLobbyType.RANKED),
                customAttributes = customAttributes
            };

            var response = await RunPlatformScript<RuyiNetLobbyResponse>(index, "Lobby_Create", JsonConvert.SerializeObject(payload));
            mCurrentLobby = response;
            PollLobbyStatus();
            return mCurrentLobby;
        }

        /// <summary>
        /// Closes a lobby and kicks all players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        public Task<RuyiNetResponse> CloseLobby(int index, string lobbyId)
        {
            mCurrentLobby = null;

            var payload = new RuyiNetLobbyCloseRequest() { lobbyId = lobbyId };
            return RunPlatformScript<RuyiNetResponse>(index, "Lobby_Close", JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        public Task<RuyiNetLobby[]> FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType)
        {
            return FindLobbies(index, numResults, lobbyType, 0);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        public Task<RuyiNetLobby[]> FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots)
        {
            return FindLobbies(index, numResults, lobbyType, freeSlots, "{}");
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        /// <param name="searchCriteria">JSON string representing parameters to search for.</param>
        public async Task<RuyiNetLobby[]> FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, string searchCriteria)
        {
            var payload = new RuyiNetLobbyFindRequest()
            {
                appId = mClient.AppId,
                numResults = numResults,
                freeSlots = freeSlots,
                ranked = (lobbyType == RuyiNetLobbyType.RANKED),
                searchCriteria = searchCriteria
            };

            var response = await RunPlatformScript<RuyiNetLobbyFindResponse>(index, "Lobby_Find", JsonConvert.SerializeObject(payload));
            var results = response.data.response.results;
            var lobbies = new RuyiNetLobby[results.count];
            for (int i = 0; i < results.count; ++i)
            {
                lobbies[i] = new RuyiNetLobby(results.items[i]);
            }

            return lobbies;
        }

        /// <summary>
        /// Joins a lobby created by another player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to join.</param>
        public async Task<RuyiNetLobby> JoinLobby(int index, string lobbyId)
        {
            var payload = new RuyiNetLobbyJoinRequest() { lobbyId = lobbyId };
            var response = await RunPlatformScript<RuyiNetLobbyResponse>(index, "Lobby_Join", JsonConvert.SerializeObject(payload));
            mCurrentLobby = response;
            PollLobbyStatus();
            return mCurrentLobby;
        }

        /// <summary>
        /// Leaves a lobby.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to leave.</param>
        public Task<RuyiNetResponse> LeaveLobby(int index, string lobbyId)
        {
            mCurrentLobby = null;
            var payload = new RuyiNetLobbyLeaveRequest() { lobbyId = lobbyId }; 
            return RunPlatformScript<RuyiNetResponse>(index, "Lobby_Leave", JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Starts a lobby game
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to start the game for.</param>
        /// <param name="connectionString">A connection string used to connect to the host.</param>
        public Task<RuyiNetResponse> StartGame(int index, string lobbyId, string connectionString)
        {
            var payload = new RuyiNetLobbyStartGameRequest() { lobbyId = lobbyId, connectionString = connectionString };
            return RunPlatformScript<RuyiNetResponse>(index, "Lobby_StartGame", JsonConvert.SerializeObject(payload));
        }

        /// <summary>
        /// Event handler for when a new player joins the lobby.
        /// </summary>
        /// <param name="profileId">The profile ID of the player joining.</param>
        public delegate void PlayerJoinEventHandler(string profileId);

        /// <summary>
        /// Event handler for when a player leaves the lobby.
        /// </summary>
        /// <param name="profileId">The profile ID of the player leaving.</param>
        public delegate void PlayerLeaveEventHandler(string profileId);

        /// <summary>
        /// Event handler for when a lobby should start a game.
        /// </summary>
        public delegate void StartGameEventHandler();

        /// <summary>
        /// Event handler for when the lobby is closed.
        /// </summary>
        public delegate void LobbyClosedEventHandler();

        /// <summary>
        /// Returns the current lobby information.
        /// </summary>
        public RuyiNetLobby CurrentLobby { get { return mCurrentLobby; } }

        /// <summary>
        /// Event handler for when a new player joins the lobby.
        /// </summary>
        public event PlayerJoinEventHandler OnPlayerJoinLobby;

        /// <summary>
        /// Event handler for when a player leaves the lobby.
        /// </summary>
        public event PlayerLeaveEventHandler OnPlayerLeaveLobby;

        /// <summary>
        /// Event handler for when a lobby should start a game.
        /// </summary>
        public event StartGameEventHandler OnLobbyStartGame;

        /// <summary>
        /// Event handler for when the lobby is closed.
        /// </summary>
        public event LobbyClosedEventHandler OnLobbyClosed;

        internal async void Update(Object source, ElapsedEventArgs e)
        {
            if (mCurrentLobby == null)
                return;

            var payload = new RuyiNetLobbyJoinRequest() { lobbyId = mCurrentLobby.LobbyId };
            var response = await RunPlatformScript<RuyiNetLobbyResponse>(mClient.ActivePlayerIndex, "Lobby_Update", JsonConvert.SerializeObject(payload));
            RuyiNetLobby updatedLobby = response;
            if (updatedLobby != null)
            {
                if (mCurrentLobby != null)
                {
                    IEnumerable<string> newPlayers = null;
                    IEnumerable<string> oldPlayers = null;

                    bool lobbyClosed = mCurrentLobby.State != "CLOSED" &&
                                       updatedLobby.State == "CLOSED";
                    bool lobbyStarted = mCurrentLobby.State != "STARTED" &&
                                        updatedLobby.State == "STARTED";

                    if (!updatedLobby.MemberProfileIds.SequenceEqual(mCurrentLobby.MemberProfileIds))
                    {
                        newPlayers = updatedLobby.MemberProfileIds.Except(mCurrentLobby.MemberProfileIds);
                        oldPlayers = mCurrentLobby.MemberProfileIds.Except(updatedLobby.MemberProfileIds);
                    }

                    mCurrentLobby = updatedLobby;

                    if (newPlayers != null)
                    {
                        foreach (var i in newPlayers)
                        {
                            Console.Write("New Player: " + i);
                            OnPlayerJoinLobby(i);
                        }
                    }

                    if (oldPlayers != null)
                    {
                        foreach (var i in oldPlayers)
                        {
                            Console.Write("Old Player: " + i);
                            OnPlayerLeaveLobby(i);
                        }
                    }

                    if (lobbyClosed)
                    {
                        for (var i = 0; i < mClient.CurrentPlayers.Length; ++i)
                        {
                            if (mClient.CurrentPlayers[i] != null)
                            {
                                await LeaveLobby(i, mCurrentLobby.LobbyId);
                            }
                        }

                        OnLobbyClosed();
                    }
                    else if (lobbyStarted)
                    {
                        OnLobbyStartGame();
                    }
                }
                else
                {
                    mCurrentLobby = updatedLobby;
                }

                PollLobbyStatus();
            }
        }

        /// <summary>
        /// /// Creates a Ruyi Net Service
        /// /// </summary>
        /// /// <param name="client">The Ruyi Net Client.</param>
        internal RuyiNetLobbyService(RuyiNetClient client)
            : base(client)
        {
            mCurrentLobby = null;
        }

        private void PollLobbyStatus()
        {
            mTimer = new Timer(POLL_FREQUENCY);
            mTimer.Elapsed += Update;
            mTimer.AutoReset = false;
            mTimer.Enabled = true;
        }

        private const double POLL_FREQUENCY = 5000;
        private Timer mTimer;
        private RuyiNetLobby mCurrentLobby;
    }
}
