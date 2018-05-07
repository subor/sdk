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
        public static implicit operator RuyiNetLobby(RuyiNetLobbyResponse other)
        {
            return new RuyiNetLobby(other.data.response);
        }

        /// <summary>
        /// Create a lobby class from a Create response
        /// </summary>
        /// <param name="response">The response recieved after creating a lobby.</param>
        public RuyiNetLobby(RuyiNetResponseGroup response)
        {
            PendingMembers = ParseMembers(response.pendingMembers);
            Members = ParseMembers(response.members);

            if (Members != null)
            {
                MemberProfileIds = new string[Members.Length];
                for (int i = 0; i < Members.Length; ++i)
                {
                    MemberProfileIds[i] = Members[i].ProfileId;
                }
            }

            LobbyId = response.groupId;
            OwnerProfileId = response.ownerId;
            State = response.name;
            CreatedAt = response.createdAt;
            UpdatedAt = response.updatedAt;
            RequestingPendingMemberCount = response.requestingPendingMemberCount;
            InvitedPendingMemberCount = response.invitedPendingMemberCount;
            MemberCount = response.memberCount;

            if (response.data != null)
            {
                MaxSlots = response.data.maxSlots;
                FreeSlots = response.data.freeSlots;
                ConnectionString = response.data.connectionString;
                LobbyType = response.data.ranked ? RuyiNetLobbyType.RANKED : RuyiNetLobbyType.PLAYER;
            }
        }

        /// <summary>
        /// Represents a single lobby member.
        /// </summary>
        public class RuyiNetLobbyMember
        {
            /// <summary>
            /// Create the lobby member.
            /// </summary>
            /// <param name="profileId">The profile ID of the player.</param>
            /// <param name="role">The role of the player.</param>
            public RuyiNetLobbyMember(string profileId, string role)
            {
                ProfileId = profileId;
                Role = role;
            }

            /// <summary>
            /// The profile ID of the player.
            /// </summary>
            public string ProfileId { get; private set; }

            /// <summary>
            /// The role of the player.
            /// </summary>
            public string Role { get; private set; }
        }

        /// <summary>
        /// A list of players that have either been invited or requested to join
        /// the lobby.
        /// </summary>
        public RuyiNetLobbyMember[] PendingMembers { get; private set; }

        /// <summary>
        /// The players who are in this lobby.
        /// </summary>
        public RuyiNetLobbyMember[] Members { get; private set; }

        /// <summary>
        /// A list of ids - useful for quickly retrieving profile data.
        /// </summary>
        public string[] MemberProfileIds { get; private set; }

        /// <summary>
        /// The unique ID of the lobby.
        /// </summary>
        public string LobbyId { get; private set; }

        /// <summary>
        /// The profile ID of the player who owns this lobby.
        /// </summary>
        public string OwnerProfileId { get; private set; }

        /// <summary>
        /// The current state of the lobby.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// A connection string used to connect to the host.
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// The type of lobby - Ranked or Player match
        /// </summary>
        public RuyiNetLobbyType LobbyType { get; private set; }

        /// <summary>
        /// When the lobby was created.
        /// </summary>
        public long CreatedAt { get; private set; }

        /// <summary>
        /// When the lobby was last updated.
        /// </summary>
        public long UpdatedAt { get; private set; }

        /// <summary>
        /// The number of players in the lobby.
        /// </summary>
        public int MemberCount { get; private set; }

        /// <summary>
        /// The maximum number of players that can be in this lobby.
        /// </summary>
        public int MaxSlots { get; private set; }

        /// <summary>
        /// The number of free slots available in this lobby.
        /// </summary>
        public int FreeSlots { get; private set; }

        /// <summary>
        /// The number of players that have requested to join the lobby.
        /// </summary>
        public int RequestingPendingMemberCount { get; private set; }

        /// <summary>
        /// The number of players that have been invited to join the lobby.
        /// </summary>
        public int InvitedPendingMemberCount { get; private set; }

        private RuyiNetLobbyMember[] ParseMembers(Dictionary<string, RuyiNetResponseGroup.Member> members)
        {
            RuyiNetLobbyMember[] response = null;
            if (members != null)
            {
                var membersCount = members.Keys.Count;
                if (membersCount > 0)
                {
                    response = new RuyiNetLobbyMember[membersCount];
                    int i = 0;
                    foreach (var k in members.Keys)
                    {
                        response[i++] = new RuyiNetLobbyMember(k, members[k].role);
                    }
                }
            }

            return response;
        }
    }
}
