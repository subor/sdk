using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a Get Summary Data request.
    /// </summary>
    [Serializable]
    public class RuyiNetGetSummaryDataForProfileIdResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        public RuyiNetFriendResponseSummaryData data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
