using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// A group received from a response.
    /// </summary>
    public class RuyiNetResponseGroup
    {
        /// <summary>
        /// Access Control List
        /// </summary>
        [Serializable]
        public class ACL
        {
            /// <summary>
            /// Access privileges of everyone else.
            /// </summary>
            public int other;

            /// <summary>
            /// Access privileges of members.
            /// </summary>
            public int member;
        }

        /// <summary>
        /// The default attributes for members.
        /// </summary>
        [Serializable]
        public class DefaultMemberAttributes { }

        /// <summary>
        /// A group member.
        /// </summary>
        [Serializable]
        public class Member
        {
            /// <summary>
            /// The role of the member.
            /// </summary>
            public string role;

            /// <summary>
            /// Attributes that can be attached to the member.
            /// </summary>
            public class Attributes { }

            /// <summary>
            /// Attributes attached to the member.
            /// </summary>
            public Attributes attributes;
        }

        /// <summary>
        /// Extra custom data
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// A connection string used to connect to the host.
            /// </summary>
            public string connectionString;

            /// <summary>
            /// The maximum number of players that can join this lobby.
            /// </summary>
            public int maxSlots;

            /// <summary>
            /// The number of players needed to fill this lobby.
            /// </summary>
            public int freeSlots;

            /// <summary>
            /// Whether or not this game is a RANKED MATCH.
            /// </summary>
            public bool ranked;
        }

        /// <summary>
        /// Extra custom data
        /// </summary>
        public Data data;

        /// <summary>
        /// The Access Control List
        /// </summary>
        public ACL acl;

        /// <summary>
        /// The default attributes for members.
        /// </summary>
        public DefaultMemberAttributes defaultMemberAttributes;

        /// <summary>
        /// A list of players that have either been invited or requested to join
        /// the lobby.
        /// </summary>
        public Dictionary<string, Member> pendingMembers;

        /// <summary>
        /// The players who are in this lobby.
        /// </summary>
        public Dictionary<string, Member> members;

        /// <summary>
        /// The App ID of the game this lobby belongs to.
        /// </summary>
        public string gameId;

        /// <summary>
        /// The type of this group.
        /// </summary>
        public string groupType;

        /// <summary>
        /// The unique ID of the group.
        /// </summary>
        public string groupId;

        /// <summary>
        /// The profile ID of the group's owner.
        /// </summary>
        public string ownerId;

        /// <summary>
        /// The name of the group.
        /// </summary>
        public string name;

        /// <summary>
        /// When the group was created.
        /// </summary>
        public long createdAt;

        /// <summary>
        /// When the lobby was last updated.
        /// </summary>
        public long updatedAt;

        /// <summary>
        /// The number of players in the lobby.
        /// </summary>
        public int memberCount;

        /// <summary>
        /// The number of players that have requested to join the lobby.
        /// </summary>
        public int requestingPendingMemberCount;

        /// <summary>
        /// The current version of the lobby.
        /// </summary>
        public int version;

        /// <summary>
        /// The number of players that have been invited to join the lobby.
        /// </summary>
        public int invitedPendingMemberCount;

        /// <summary>
        /// Whether or not the group is open to other players.
        /// </summary>
        public bool isOpenGroup;
    }
}
