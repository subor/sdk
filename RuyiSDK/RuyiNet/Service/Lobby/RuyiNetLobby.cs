using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A lobby used in matchmaking for multiplayer games.
    /// </summary>
    public class RuyiNetLobby
    {
        /// <summary>
        /// Implicit conversion operator.
        /// </summary>
        /// <param name="other">The response after creating a lobby.</param>
        public static implicit operator RuyiNetLobby(RuyiNetLobbyResponseData data)
        {
            return new RuyiNetLobby(data);
        }

        /// <summary>
        /// Create a lobby class from a Create response
        /// </summary>
        /// <param name="data">The data containing the lobby information.</param>
        public RuyiNetLobby(RuyiNetLobbyResponseData data)
        {
            if (data != null)
            {
                GameId = data.gameId;
                LobbyId = data.lobbyId;
                JSONAttributes = data.attributes;
                MemberPlayerIds = new List<string>(data.memberPlayerIds);
                ConnectionString = data.connectionString;
                LobbyState = (RuyiNetLobbyState)Enum.Parse(typeof(RuyiNetLobbyState), data.lobbyState);
                LobbyType = (RuyiNetLobbyType)Enum.Parse(typeof(RuyiNetLobbyType), data.lobbyType);
                Created = data.created;
                Updated = data.updated;
                MaxSlots = data.maxSlots;
                IsOpen = data.isOpen;
                FreeSlots = data.freeSlots;
                OwnerPlayerId = data.ownerPlayerId;
            }
        }

        /// <summary>
        /// The ID of the game this lobby belongs to.
        /// </summary>
        public string GameId { get; private set; }

        /// <summary>
        /// The unique ID of the lobby;
        /// </summary>
        public string LobbyId { get; private set; }

        /// <summary>
        /// JSON string containing custom attributes.
        /// </summary>
        public Dictionary<string, object> JSONAttributes { get; private set; }

        /// <summary>
        /// A list of player IDs of the members.
        /// </summary>
        public List<string> MemberPlayerIds { get; set; }

        /// <summary>
        /// The connection string for starting a game.
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// The current state of the lobby.
        /// </summary>
        public RuyiNetLobbyState LobbyState { get; private set; }

        /// <summary>
        /// The type of lobby (PLAYER or RANKED).
        /// </summary>
        public RuyiNetLobbyType LobbyType { get; private set; }

        /// <summary>
        /// When the lobby was created.
        /// </summary>
        public long Created { get; private set; }

        /// <summary>
        /// When the lobby was last updated.
        /// </summary>
        public long Updated { get; private set; }

        /// <summary>
        /// The maximum number of players that can join the lobby.
        /// </summary>
        public int MaxSlots { get; private set; }

        /// <summary>
        /// Whether or not players can join the lobby.
        /// </summary>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// The number of free slots available.
        /// </summary>
        public int FreeSlots { get; private set; }

        /// <summary>
        /// The ID of the player that currently owns this lobby.
        /// </summary>
        public string OwnerPlayerId { get; private set; }
    }
}
