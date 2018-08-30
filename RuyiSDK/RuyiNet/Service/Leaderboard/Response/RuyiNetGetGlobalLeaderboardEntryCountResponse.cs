using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response recieved from an achievemet request (gamification service).
    /// </summary>
    public class RuyiNetGetGlobalLeaderboardEntryCountResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The number of entries in the specified leaderboard.
            /// </summary>
            public int entryCount;
        }

        /// <summary>
        /// The data returned with the response.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }
}
