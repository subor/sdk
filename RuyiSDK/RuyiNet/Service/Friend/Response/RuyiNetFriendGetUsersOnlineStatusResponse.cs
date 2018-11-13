using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a Get Users Online Status request.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendGetUsersOnlineStatusResponse
    {
        /// <summary>
        /// Represents the response data.,
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// A list of online statuses.
            /// </summary>
            public RuyiNetFriendResponseOnlineStatus[] onlineStatus;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
