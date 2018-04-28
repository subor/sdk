using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Ruyi
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
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType, Action<RuyiNetLobby> callback)
        {
            CreateLobby(index, maxSlots, lobbyType, "{}", callback);
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="customAttributes">JSON string of custom attributes to attach to this lobby.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType,
            string customAttributes, Action<RuyiNetLobby> callback)
        {
            var payload = new RuyiNetLobbyCreateRequest()
            {
                appId = mClient.AppId,
                maxSlots = maxSlots,
                ranked = (lobbyType == RuyiNetLobbyType.RANKED),
                customAttributes = customAttributes
            };

            RunPlatformScript(index, "Lobby_Create", JsonConvert.SerializeObject(payload),
                (RuyiNetLobbyResponse response) =>
                {
                    mCurrentLobby = response;
                    callback(mCurrentLobby);
                    PollLobbyStatus();
                });
        }

        /// <summary>
        /// Closes a lobby and kicks all players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CloseLobby(int index, string lobbyId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            mCurrentLobby = null;

            var payload = new RuyiNetLobbyCloseRequest() { lobbyId = lobbyId };
            RunPlatformScript(index, "Lobby_Close", JsonConvert.SerializeObject(payload), callback);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType,
            Action<RuyiNetLobby[]> callback)
        {
            FindLobbies(index, numResults, lobbyType, 0, callback);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType,
            int freeSlots, Action<RuyiNetLobby[]> callback)
        {
            FindLobbies(index, numResults, lobbyType, freeSlots, "{}", callback);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        /// <param name="searchCriteria">JSON string representing parameters to search for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType,
            int freeSlots, string searchCriteria, Action<RuyiNetLobby[]> callback)
        {
            var payload = new RuyiNetLobbyFindRequest()
            {
                appId = mClient.AppId,
                numResults = numResults,
                freeSlots = freeSlots,
                ranked = (lobbyType == RuyiNetLobbyType.RANKED),
                searchCriteria = searchCriteria
            };

            RunPlatformScript(index, "Lobby_Find", JsonConvert.SerializeObject(payload),
                (RuyiNetLobbyFindResponse response) =>
                {
                    var results = response.data.response.results;
                    var lobbies = new RuyiNetLobby[results.count];
                    for (int i = 0; i < results.count; ++i)
                    {
                        lobbies[i] = new RuyiNetLobby(results.items[i]);
                    }

                    callback(lobbies);
                });
        }

        /// <summary>
        /// Joins a lobby created by another player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to join.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void JoinLobby(int index, string lobbyId, Action<RuyiNetLobby> callback)
        {
            var payload = new RuyiNetLobbyJoinRequest() { lobbyId = lobbyId };
            RunPlatformScript(index, "Lobby_Join", JsonConvert.SerializeObject(payload),
                (RuyiNetLobbyResponse response) =>
                {
                    mCurrentLobby = response;
                    callback(mCurrentLobby);
                    PollLobbyStatus();
                });
        }

        /// <summary>
        /// Leaves a lobby.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to leave.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void LeaveLobby(int index, string lobbyId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            mCurrentLobby = null;

            var payload = new RuyiNetLobbyLeaveRequest() { lobbyId = lobbyId };
            RunPlatformScript(index, "Lobby_Leave", JsonConvert.SerializeObject(payload), callback);
        }

        /// <summary>
        /// Starts a lobby game
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to start the game for.</param>
        /// <param name="connectionString">A connection string used to connect to the host.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void StartGame(int index, string lobbyId, string connectionString, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            var payload = new RuyiNetLobbyStartGameRequest() { lobbyId = lobbyId, connectionString = connectionString };
            RunPlatformScript(index, "Lobby_StartGame", JsonConvert.SerializeObject(payload), callback);
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

        internal void Update(Object source, ElapsedEventArgs e)
        {
            if (mCurrentLobby != null)
            {
                var payload = new RuyiNetLobbyJoinRequest() { lobbyId = mCurrentLobby.LobbyId };
                RunPlatformScript(mClient.ActivePlayerIndex, "Lobby_Update", JsonConvert.SerializeObject(payload),
                    (RuyiNetLobbyResponse response) =>
                    {
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
                                            LeaveLobby(i, mCurrentLobby.LobbyId, null);
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
                    });
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
