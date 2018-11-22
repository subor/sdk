using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a GetLeaderboardVersions request.
    /// </summary>
    public class RuyiNetGetGlobalLeaderboardVersionsResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
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
            /// The type of leaderboard rotation.
            /// </summary>
            public string rotationType;

            /// <summary>
            /// The number of versions retained.
            /// </summary>
            public int retainedCount;

            /// <summary>
            /// Represents a leaderboard version.
            /// </summary>
            [Serializable]
            public class VersionInfo
            {
                /// <summary>
                /// The ID of this version.
                /// </summary>
                public int versionId;

                /// <summary>
                /// The time this version starts.
                /// </summary>
                public long startingAt;

                /// <summary>
                /// The time this version ends.
                /// </summary>
                public long endingAt;
            }

            /// <summary>
            /// A list of versions currently retained.
            /// </summary>
            public VersionInfo[] versions;
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
