namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a party invitation.
    /// </summary>
    public class RuyiNetPartyInvitation
    {
        /// <summary>
        /// Convert from response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        public static implicit operator RuyiNetPartyInvitation(RuyiNetPartyInvitationData data)
        {
            return new RuyiNetPartyInvitation()
            {
                ToPlayerId = data.toPlayerId,
                FromPlayerId = data.fromPlayerId,
                PartyId = data.partyId,
            };
        }

        /// <summary>
        /// The ID of the player the invitation was sent to.
        /// </summary>
        public string ToPlayerId { get; private set; }

        /// <summary>
        /// The ID of the player that sent the invitation.
        /// </summary>
        public string FromPlayerId { get; private set; }

        /// <summary>
        /// The ID of the party the player was invited to.
        /// </summary>
        public string PartyId { get; private set; }
    }
}
