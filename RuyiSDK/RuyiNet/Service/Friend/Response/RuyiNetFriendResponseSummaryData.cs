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
        public string profileName;

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public string profileId;

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
    }
}
