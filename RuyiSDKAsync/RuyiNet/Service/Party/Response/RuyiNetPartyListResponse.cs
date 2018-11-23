using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a party list request.
    /// </summary>
    [Serializable]
    public class RuyiNetPartyListResponse
    {
        /// <summary>
        /// Represents the response data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// The list of parties.
            /// </summary>
            public RuyiNetPartyData[] parties;
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
