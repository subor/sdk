using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a Read Friends Entities request.
    /// </summary>
    [Serializable]
    public class RuyiNetReadFriendsEntitiesResponse
    {
        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;

        /// <summary>
        /// Represents the response data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// The entities retrieves.
            /// </summary>
            public RuyiNetEntityData[] results;
        };

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;
    }
}
