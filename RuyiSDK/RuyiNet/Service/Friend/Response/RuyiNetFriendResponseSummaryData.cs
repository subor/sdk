using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents summary data from a response.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendResponseSummaryData
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string playerName;

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public string playerId;

        /// <summary>
        /// The resource location of the profile picture.
        /// </summary>
        public string pictureUrl;

        /// <summary>
        /// The summary data.
        /// </summary>
        public Dictionary<string, object> summaryFriendData;

        /// <summary>
        /// Email address.
        /// </summary>
        public string email;

        /// <summary>
        /// Whether or not the player is online.
        /// </summary>
        public bool isOnline;
    }
}
