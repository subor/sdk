using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The response data included with responses from the Lobby API.
    /// </summary>
    [Serializable]
    public class RuyiNetLobbyResponseData
    {
        /// <summary>
        /// The ID of the game this lobby belongs to.
        /// </summary>
        public string gameId;

        /// <summary>
        /// The unique ID of the lobby;
        /// </summary>
        public string lobbyId;

        /// <summary>
        /// JSON string containing custom attributes.
        /// </summary>
        public string attributes;

        /// <summary>
        /// A list of player IDs of the members.
        /// </summary>
        public string[] memberPlayerIds;

        /// <summary>
        /// The connection string for starting a game.
        /// </summary>
        public string connectionString;

        /// <summary>
        /// The current state of the lobby.
        /// </summary>
        public string lobbyState;

        /// <summary>
        /// The type of lobby (PLAYER or RANKED).
        /// </summary>
        public string lobbyType;

        /// <summary>
        /// When the lobby was created.
        /// </summary>
        public long created;

        /// <summary>
        /// When the lobby was last updated.
        /// </summary>
        public long updated;

        /// <summary>
        /// The maximum number of players that can join the lobby.
        /// </summary>
        public int maxSlots;

        /// <summary>
        /// Whether or not players can join the lobby.
        /// </summary>
        public bool isOpen;

        /// <summary>
        /// The number of free slots available.
        /// </summary>
        public int freeSlots;

        /// <summary>
        /// The ID of the player that currently owns this lobby.
        /// </summary>
        public string ownerPlayerId;
    }
}
