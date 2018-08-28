namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a Party.
    /// </summary>
    public class RuyiNetParty
    {
        /// <summary>
        /// Convert from response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        public static implicit operator RuyiNetParty(RuyiNetPartyData data)
        {
            return new RuyiNetParty()
            {
                Created = data.created,
                MemberPlayerIds = data.memberPlayerIds,
                Updated = data.updated,
                PartyId = data.partyId,
                OwnerPlayerId = data.ownerPlayerId,
            };
        }

        /// <summary>
        /// When the party was created.
        /// </summary>
        public long Created { get; private set; }

        /// <summary>
        /// A list of members' player IDs.
        /// </summary>
        public string[] MemberPlayerIds { get; private set; }

        /// <summary>
        /// When the party was last updated.
        /// </summary>
        public long Updated { get; private set; }

        /// <summary>
        /// The ID of the party.
        /// </summary>
        public string PartyId { get; private set; }

        /// <summary>
        /// The ID of the owning player.
        /// </summary>
        public string OwnerPlayerId { get; private set; }
    }
}
