using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response recieved from retrieving a player's score.
    /// </summary>
    public class RuyiNetGetPlayerScoreResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// Represents a player score.
            /// </summary>
            [Serializable]
            public class Score
            {
                /// <summary>
                /// The player's score.
                /// </summary>
                public int score;

                /// <summary>
                /// Data specified by the game developer.
                /// </summary>
                public string data;

                /// <summary>
                /// When this score entry was created.
                /// </summary>
                public long createdAt;

                /// <summary>
                /// When this score entry was last updated.
                /// </summary>
                public long updatedAt;

                /// <summary>
                /// The ID of the leaderboard this score is an entry for.
                /// </summary>
                public string leaderboardId;

                /// <summary>
                /// The version of the leaderboard this score is an entry for.
                /// </summary>
                public int versionId;
            }

            /// <summary>
            /// The player's score entry.
            /// </summary>
            public Score score;
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
