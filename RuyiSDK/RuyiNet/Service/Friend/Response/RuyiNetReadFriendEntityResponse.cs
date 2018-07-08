using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response from a Read Friend Entity request.
    /// </summary>
    [Serializable]
    public class RuyiNetReadFriendEntityResponse
    {
        /// <summary>
        /// The status of the response (200 == OK).
        /// </summary>
        public int status;

        /// <summary>
        /// The entity data.
        /// </summary>
        public RuyiNetEntityData data;
    }
}
