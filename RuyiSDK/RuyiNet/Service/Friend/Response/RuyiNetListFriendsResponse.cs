using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The response after a friend list is requested.
    /// </summary>
    [Serializable]
    public class RuyiNetListFriendsResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The time this data was fetched on the server.
            /// </summary>
            public long server_time;

            /// <summary>
            /// The list of friends.
            /// </summary>
            public RuyiNetFriendResponseSummaryData[] friends;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status code of the returned data.
        /// </summary>
        public int status;
    }
}
