using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response received after creating a lobby.
    /// </summary>
    [Serializable]
    public class RuyiNetLobbyResponse
    {

        /// <summary>
        /// The data.
        /// </summary>
        public RuyiNetLobbyResponseData data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
