using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, Action<RuyiNetLobby> callback)
        {
            CreateLobby(clientIndex, maxSlots, lobbyType, true, "{}", callback);
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="jsonAttributes">JSON string of custom attributes to attach to this lobby.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, string jsonAttributes, Action<RuyiNetLobby> callback)
        {
            CreateLobby(clientIndex, maxSlots, lobbyType, true, jsonAttributes, callback);
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="isOpen">Whether or not the lobby is open by default.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen, Action<RuyiNetLobby> callback)
        {
            CreateLobby(clientIndex, maxSlots, lobbyType, isOpen, "{}", callback);
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="isOpen">Whether or not the lobby is open by default.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="jsonAttributes">JSON string of custom attributes to attach to this lobby.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen, string jsonAttributes, Action<RuyiNetLobby> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_CreateLobby((BrainCloudApi.LobbyType)lobbyType, maxSlots, isOpen, jsonAttributes, clientIndex);
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyResponse response) => OnLobbyResponse(callback, response));
        }

        /// <summary>
        /// Destroys a lobby.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void DestroyLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_DestroyLobby(lobbyId, clientIndex);
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyResponse response) => OnLobbyResponse(callback, response));
        }

        /// <summary>
        /// Opens a lobby so players can join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void OpenLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_OpenLobby(lobbyId, clientIndex);
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyResponse response) => OnLobbyResponse(callback, response));
        }

        /// <summary>
        /// Closes a lobby so players cant join anymore.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void CloseLobby(int clientIndex, string lobbyId, Action callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_CloseLobby(lobbyId, clientIndex);
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetResponse response) => OnResponse(callback));
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType,
            Action<RuyiNetLobby[]> callback)
        {
            FindLobbies(clientIndex, numResults, lobbyType, 0, callback);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, Action<RuyiNetLobby[]> callback)
        {
            FindLobbies(clientIndex, numResults, lobbyType, freeSlots, "{}", callback);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        /// <param name="jsonAttributes">JSON string representing parameters to search for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, string jsonAttributes, Action<RuyiNetLobby[]> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_FindLobbies(freeSlots, numResults, jsonAttributes, clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyFindResponse response) => OnLobbyFindResponse(callback, response));
        }

        /// <summary>
        /// Searches for lobbies with the player's friends.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindFriendsLobbies(int clientIndex, Action<RuyiNetLobby[]> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_FindFriendsLobbies(clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyFindResponse response) => OnLobbyFindResponse(callback, response));
        }

        /// <summary>
        /// Searches for lobbies the current player is a member of.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetMyLobbies(int clientIndex, Action<RuyiNetLobby[]> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_GetMyLobbies(clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyFindResponse response) => OnLobbyFindResponse(callback, response));
        }

        /// <summary>
        /// Joins a lobby created by another player.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to join.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void JoinLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_JoinLobby(lobbyId, clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyResponse response) => OnLobbyResponse(callback, response));
        }

        /// <summary>
        /// Leaves a lobby.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to leave.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void LeaveLobby(int clientIndex, string lobbyId, Action callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_LeaveLobby(lobbyId, clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetResponse response) => OnResponse(callback));
        }

        /// <summary>
        /// Starts a lobby game
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to start the game for.</param>
        /// <param name="connectionString">A connection string used to connect to the host.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void StartGame(int clientIndex, string lobbyId, string connectionString, Action<RuyiNetLobby> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    return mClient.BCService.Lobby_StartGame(lobbyId, connectionString, clientIndex); ;
                }
                catch (Exception e)
                {
                    Logging.Logger.Log("", Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetLobbyResponse response) => OnLobbyResponse(callback, response));
        }

        /// <summary>
        /// Prototype for a Lobby Created Callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        /// <param name="lobby">The lobby just created.</param>
        public delegate void LobbyCreatedEvent(int clientIndex, string lobbyId, RuyiNetLobby lobby);

        /// <summary>
        /// Prototype for a Lobby destroyed callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        public delegate void LobbyDestroyedEvent(int clientIndex, string lobbyId);

        /// <summary>
        /// Prototype for a Lobby Opened callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        public delegate void LobbyOpenedEvent(int clientIndex, string lobbyId);

        /// <summary>
        /// Prototype for a Lobby Closed callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        public delegate void LobbyClosedEvent(int clientIndex, string lobbyId);

        /// <summary>
        /// Prototype for a Lobby Game Started callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        /// <param name="connectionString">The string used to connect to the game.</param>
        public delegate void LobbyGameStartedEvent(int clientIndex, string lobbyId, string connectionString);

        /// <summary>
        /// Prototype for a Lobby Player Joined callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        /// <param name="playerId">The ID of the player.</param>
        public delegate void LobbyPlayerJoinedEvent(int clientIndex, string lobbyId, string playerId);

        /// <summary>
        /// Prototype for a Lobby Player Left callback.
        /// </summary>
        /// <param name="clientIndex">The index of the client that is in the lobby.</param>
        /// <param name="lobbyId">The ID of the lobby.</param>
        /// <param name="playerId">The ID of the player.</param>
        public delegate void LobbyPlayerLeftEvent(int clientIndex, string lobbyId, string playerId);

        /// <summary>
        /// Called when a lobby is created.
        /// </summary>
        public event LobbyCreatedEvent OnLobbyCreated;

        /// <summary>
        /// Called when a lobby is destroyed.
        /// </summary>
        public event LobbyDestroyedEvent OnLobbyDestroyed;

        /// <summary>
        /// Called when a lobby is opened.
        /// </summary>
        public event LobbyOpenedEvent OnLobbyOpened;

        /// <summary>
        /// Called when a lobby is closed.
        /// </summary>
        public event LobbyClosedEvent OnLobbyClosed;

        /// <summary>
        /// Called when a lobby game is started.
        /// </summary>
        public event LobbyGameStartedEvent OnLobbyGameStarted;

        /// <summary>
        /// Called when a player joins a lobby.
        /// </summary>
        public event LobbyPlayerJoinedEvent OnLobbyPlayerJoined;

        /// <summary>
        /// Called when a player leaves a lobby.
        /// </summary>
        public event LobbyPlayerLeftEvent OnLobbyPlayerLeft;


        internal void Update(Object source, ElapsedEventArgs e)
        {
            var updatedLobbies = new Dictionary<string, RuyiNetLobby>();
            for (var clientIndex = 0; clientIndex < mClient.CurrentPlayers.Length; ++clientIndex)
            {
                if (mClient.CurrentPlayers[clientIndex] != null)
                {
                    GetMyLobbies(clientIndex, (RuyiNetLobby[] lobbies) =>
                    {
                        if (lobbies != null)
                        {
                            foreach (var updatedLobby in lobbies)
                            {
                                var lobbyId = updatedLobby.LobbyId;
                                if (mLobbies.ContainsKey(lobbyId))
                                {
                                    var currentLobby = mLobbies[lobbyId];
                                    if (!currentLobby.IsOpen &&
                                        updatedLobby.IsOpen)
                                    {
                                        OnLobbyOpened(clientIndex, lobbyId);
                                    }

                                    if (currentLobby.IsOpen &&
                                        !updatedLobby.IsOpen)
                                    {
                                        OnLobbyClosed(clientIndex, lobbyId); 
                                    }

                                    if (currentLobby.LobbyState == RuyiNetLobbyState.CREATED &&
                                        updatedLobby.LobbyState == RuyiNetLobbyState.STARTED)
                                    {
                                        OnLobbyGameStarted(clientIndex, lobbyId, updatedLobby.ConnectionString);
                                    }

                                    foreach (var playerId in currentLobby.MemberPlayerIds)
                                    {
                                        if (!updatedLobby.MemberPlayerIds.Contains(playerId))
                                        {
                                            OnLobbyPlayerLeft(clientIndex, lobbyId, playerId);
                                        }
                                    }

                                    foreach (var playerId in updatedLobby.MemberPlayerIds)
                                    {
                                        if (!currentLobby.MemberPlayerIds.Contains(playerId))
                                        {
                                            OnLobbyPlayerJoined(clientIndex, lobbyId, playerId);
                                        }
                                    }
                                }
                                else
                                {
                                    OnLobbyCreated(clientIndex, updatedLobby.LobbyId, updatedLobby);
                                }

                                updatedLobbies[updatedLobby.LobbyId] = updatedLobby;
                            }
                        }
                    });
                }
            }

            foreach (var lobbyId in mLobbies.Keys)
            {
                if (!updatedLobbies.ContainsKey(lobbyId))
                {
                    var currentLobby = mLobbies[lobbyId];
                    for (var clientIndex = 0; clientIndex < mClient.CurrentPlayers.Length; ++clientIndex)
                    {
                        if (currentLobby.MemberPlayerIds.Contains(mClient.CurrentPlayers[clientIndex].profileId))
                        {
                            OnLobbyDestroyed(clientIndex, lobbyId);
                        }
                    }
                }
            }

            mLobbies = updatedLobbies;
        }

        /// <summary>
        /// /// Creates a Ruyi Net Service
        /// /// </summary>
        /// /// <param name="client">The Ruyi Net Client.</param>
        internal RuyiNetLobbyService(RuyiNetClient client)
            : base(client)
        {
            mLobbies = new Dictionary<string, RuyiNetLobby>();
        }

        private void PollLobbyStatus()
        {
            mTimer = new Timer(POLL_FREQUENCY);
            mTimer.Elapsed += Update;
            mTimer.AutoReset = false;
            mTimer.Enabled = true;
        }

        private void OnResponse(Action callback)
        {
            if (callback != null)
            {
                callback();
            }
        }

        private void OnLobbyResponse(Action<RuyiNetLobby> callback, RuyiNetLobbyResponse response)
        {
            if (callback != null)
            {
                if (response.status == RuyiNetHttpStatus.OK)
                {
                    callback(response.data);
                }
                else
                {
                    callback(null);
                }
            }
        }

        private void OnLobbyFindResponse(Action<RuyiNetLobby[]> callback, RuyiNetLobbyFindResponse response)
        {
            if (callback != null)
            {
                var lobbies = response.GetLobbies();
                callback(lobbies);
            }
        }

        private Dictionary<string, RuyiNetLobby> mLobbies;
        private const double POLL_FREQUENCY = 5000;
        private Timer mTimer;
    }
}
