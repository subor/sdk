using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response recieved from an achievemet request (gamification service).
    /// </summary>
    public class RuyiNetListAllLeaderboardsResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The number of leaderboards in the list.
            /// </summary>
            public int leaderboardListCount;

            /// <summary>
            /// Represents a single leaderboard config.
            /// </summary>
            public class LeaderboardInfo
            {
                /// <summary>
                /// The ID of the leaderboard.
                /// </summary>
                public string leaderboardId;

                /// <summary>
                /// The type of leaderboard.
                /// </summary>
                public string leaderboardType;

                /// <summary>
                /// When the leaderboard will next be reset.
                /// </summary>
                public long resetAt;

                /// <summary>
                /// The type of rotation this leaderboard uses.
                /// </summary>
                public string rotationType;

                /// <summary>
                /// The current version of the leaderboard.
                /// </summary>
                public int currentVersionId;

                /// <summary>
                /// The maximum number of leaderboards retained.
                /// </summary>
                public int maxRetainedCount;

                /// <summary>
                /// The actual number of versions currrent retained.
                /// </summary>
                public int retainedVersionsCount;

                /// <summary>
                /// Custom data specified by the developer.
                /// </summary>
                public string data;
            }

            /// <summary>
            /// The list of leaderboards.
            /// </summary>
            public LeaderboardInfo[] leaderboardList;
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
