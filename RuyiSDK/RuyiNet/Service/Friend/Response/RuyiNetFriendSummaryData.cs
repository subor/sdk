using System;
using System.Collections.Generic;
using System.Text;

namespace Ruyi.SDK.RuyiNet.Service.Friend.Response
{
    class RuyiNetFriendSummaryData
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
