using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents data from a Get Users Status response.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendResponseOnlineStatus
    {
        /// <summary>
        /// Does the player actually exist?
        /// </summary>
        public bool userValid;

        /// <summary>
        /// The player's ID.
        /// </summary>
        public string profileId;

        /// <summary>
        /// Is the player online?
        /// </summary>
        public bool isOnline;
    }
}
