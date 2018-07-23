using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents invitation data from a party response.
    /// </summary>
    [Serializable]
    public class RuyiNetPartyInvitationData
    {
        /// <summary>
        /// The ID of the player the invitation was sent to.
        /// </summary>
        public string toPlayerId;

        /// <summary>
        /// The ID of the player that sent the invitation.
        /// </summary>
        public string fromPlayerId;

        /// <summary>
        /// The ID of the party the player was invited to.
        /// </summary>
        public string partyId;
    }
}
