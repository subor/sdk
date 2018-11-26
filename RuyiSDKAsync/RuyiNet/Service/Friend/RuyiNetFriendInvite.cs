using System;
using System.Collections.Generic;
using System.Text;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a friend invitation.
    /// </summary>
    public class RuyiNetFriendInvite
    {
        /// <summary>
        /// Convert from response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        public static implicit operator RuyiNetFriendInvite(RuyiNetFriendResponseInvite data)
        {
            return new RuyiNetFriendInvite()
            {
                FromPlayerId = data.fromPlayerId,
                ToPlayerId = data.toPlayerId,
            };
        }

        /// <summary>
        /// The ID of the player who sent the invite.
        /// </summary>
        public string FromPlayerId { get; private set; }

        /// <summary>
        /// The ID of the player who recieved the invite.
        /// </summary>
        public string ToPlayerId { get; private set; }
    }
}
