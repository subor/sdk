using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents party data returned from a response.
    /// </summary>
    [Serializable]
    public class RuyiNetPartyData
    {
        /// <summary>
        /// When the party was created.
        /// </summary>
        public long created;

        /// <summary>
        /// A list of members' player IDs.
        /// </summary>
        public string[] memberPlayerIds;

        /// <summary>
        /// When the party was last updated.
        /// </summary>
        public long updated;

        /// <summary>
        /// The ID of the party.
        /// </summary>
        public string partyId;

        /// <summary>
        /// The ID of the owning player.
        /// </summary>
        public string ownerPlayerId;
    }
}
