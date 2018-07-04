using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents the data from a List Invites request.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendResponseInvite
    {
        /// <summary>
        /// The ID of the player who sent this invite.
        /// </summary>
        public string fromPlayerId;

        /// <summary>
        /// The ID of the player this invite was sent to.
        /// </summary>
        public string toPlayerId;
    }
}
