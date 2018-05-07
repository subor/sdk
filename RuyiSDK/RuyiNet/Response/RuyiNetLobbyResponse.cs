using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Response received after creating a lobby.
    /// </summary>
    [Serializable]
    public class RuyiNetLobbyResponse
    {
        /// <summary>
        /// Data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The response.
            /// </summary>
            public RuyiNetResponseGroup response;

            /// <summary>
            /// Whether or not the server-side script was successful.
            /// </summary>
            public bool success;
        }

        /// <summary>
        /// The data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
