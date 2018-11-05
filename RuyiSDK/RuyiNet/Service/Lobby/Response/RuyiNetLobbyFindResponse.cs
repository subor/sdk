using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The response recieved on finding a lobby.
    /// </summary>
    [Serializable]
    public class RuyiNetLobbyFindResponse
    {
        /// <summary>
        /// The data
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The list of returned lobbies.
            /// </summary>
            public RuyiNetLobbyResponseData[] lobbies;
            
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
