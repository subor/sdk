using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a Find Users Response.
    /// </summary>
    [Serializable]
    public class RuyiNetGetSummaryDataMultipleResponse
    {
        /// <summary>
        /// Represents the response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// A list of profiles.
            /// </summary>
            public RuyiNetFriendResponseSummaryData[] profiles;
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
