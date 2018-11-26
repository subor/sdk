using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a Find Users Response.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendFindUsersResponse
    {
        /// <summary>
        /// Represents the response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// Number of matches.
            /// </summary>
            public int matchedCount;

            /// <summary>
            /// A list of matches.
            /// </summary>
            public RuyiNetFriendResponseSummaryData[] matches;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }
}
