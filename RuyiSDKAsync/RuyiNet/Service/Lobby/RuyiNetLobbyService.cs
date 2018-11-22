using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
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
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        public Task<RuyiNetLobbyResponse> CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType)
        {
            return CreateLobby(clientIndex, maxSlots, lobbyType, true, "{}");
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="jsonAttributes">JSON string of custom attributes to attach to this lobby.</param>
        public Task<RuyiNetLobbyResponse> CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, string jsonAttributes)
        {
            return CreateLobby(clientIndex, maxSlots, lobbyType, true, jsonAttributes);
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="isOpen">Whether or not the lobby is open by default.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        public Task<RuyiNetLobbyResponse> CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen)
        {
            return CreateLobby(clientIndex, maxSlots, lobbyType, isOpen, "{}");
        }

        /// <summary>
        /// Creates a lobby that other players can find and join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
        /// <param name="isOpen">Whether or not the lobby is open by default.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="jsonAttributes">JSON string of custom attributes to attach to this lobby.</param>
        public async Task<RuyiNetLobbyResponse> CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen, string jsonAttributes)
        {
            var resp = await mClient.BCService.Lobby_CreateLobbyAsync((BrainCloudApi.LobbyType)lobbyType, maxSlots, isOpen, jsonAttributes, clientIndex, token);
            return mClient.Process<RuyiNetLobbyResponse>(resp);
        }

        /// <summary>
        /// Destroys a lobby.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public async Task<RuyiNetLobbyResponse> DestroyLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)
        {
            var resp = await mClient.BCService.Lobby_DestroyLobbyAsync(lobbyId, clientIndex, token);
            return mClient.Process<RuyiNetLobbyResponse>(resp);
        }

        /// <summary>
        /// Opens a lobby so players can join.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        public async Task<RuyiNetLobbyResponse> OpenLobby(int clientIndex, string lobbyId)
        {
            var resp = await mClient.BCService.Lobby_OpenLobbyAsync(lobbyId, clientIndex, token);
            return mClient.Process<RuyiNetLobbyResponse>(resp);
        }

        /// <summary>
        /// Closes a lobby so players cant join anymore.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to close.</param>
        public async Task<RuyiNetResponse> CloseLobby(int clientIndex, string lobbyId)
        {
            var resp = await mClient.BCService.Lobby_CloseLobbyAsync(lobbyId, clientIndex, token);
            return mClient.Process<RuyiNetResponse>(resp);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        public Task<RuyiNetLobbyFindResponse> FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType,
            Action<RuyiNetLobby[]> callback)
        {
            return FindLobbies(clientIndex, numResults, lobbyType, 0);
        }

        /// <summary>
        /// Searches for lobbies created by other players.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="numResults">The maximum number of lobbies to return.</param>
        /// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
        /// <param name="freeSlots">The number of free slots needed.</param>
        public Task<RuyiNetLobbyFindResponse> FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots)
        {
            return FindLobbies(clientIndex, numResults, lobbyType, freeSlots, "{}");
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
        public async Task<RuyiNetLobbyFindResponse> FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, string jsonAttributes)
        {
            var resp = await mClient.BCService.Lobby_FindLobbiesAsync(freeSlots, numResults, jsonAttributes, clientIndex, token);
            return mClient.Process<RuyiNetLobbyFindResponse>(resp);
        }

        /// <summary>
        /// Searches for lobbies with the player's friends.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        public async Task<RuyiNetLobbyFindResponse> FindFriendsLobbies(int clientIndex)
        {
            var resp = await mClient.BCService.Lobby_FindFriendsLobbiesAsync(clientIndex, token);
            return mClient.Process<RuyiNetLobbyFindResponse>(resp);
        }

        /// <summary>
        /// Searches for lobbies the current player is a member of.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        public async Task<RuyiNetLobbyFindResponse> GetMyLobbies(int clientIndex)
        {
            var resp = await mClient.BCService.Lobby_GetMyLobbiesAsync(clientIndex, token);
            return mClient.Process<RuyiNetLobbyFindResponse>(resp);
        }

        /// <summary>
        /// Joins a lobby created by another player.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to join.</param>
        public async Task<RuyiNetLobbyFindResponse> JoinLobby(int clientIndex, string lobbyId)
        {
            var resp = await mClient.BCService.Lobby_JoinLobbyAsync(lobbyId, clientIndex, token);
            return mClient.Process<RuyiNetLobbyFindResponse>(resp);
        }

        /// <summary>
        /// Leaves a lobby.
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to leave.</param>
        public async Task<RuyiNetResponse> LeaveLobby(int clientIndex, string lobbyId)
        {
            var resp = await mClient.BCService.Lobby_LeaveLobbyAsync(lobbyId, clientIndex, token);
            return mClient.Process<RuyiNetResponse>(resp);
        }

        /// <summary>
        /// Starts a lobby game
        /// </summary>
        /// <param name="clientIndex">The index of user</param>
        /// <param name="lobbyId">The ID of the lobby to start the game for.</param>
        /// <param name="connectionString">A connection string used to connect to the host.</param>
        public async Task<RuyiNetLobbyResponse> StartGame(int clientIndex, string lobbyId, string connectionString)
        {
            var resp = await mClient.BCService.Lobby_StartGameAsync(lobbyId, connectionString, clientIndex, token);
            return mClient.Process<RuyiNetLobbyResponse>(resp);
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


        internal async Task Update(Object source, ElapsedEventArgs e)
        {
            var updatedLobbies = new Dictionary<string, RuyiNetLobby>();
            for (var clientIndex = 0; clientIndex < mClient.CurrentPlayers.Length; ++clientIndex)
            {
                if (mClient.CurrentPlayers[clientIndex] != null)
                {
                    var response = await GetMyLobbies(clientIndex);
                    var lobbies = response.GetLobbies();
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
        
        private Dictionary<string, RuyiNetLobby> mLobbies;
    }
}
