using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a response from a party service request
    /// </summary>
    [Serializable]
    public class RuyiNetPartyResponse
    {
        /// <summary>
        /// Represents the response data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// The party after this request.
            /// </summary>
            public RuyiNetPartyData party;
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
