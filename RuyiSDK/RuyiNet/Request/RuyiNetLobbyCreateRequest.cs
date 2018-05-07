using System;

namespace Ruyi.SDK.Cloud
{
    [Serializable]
    class RuyiNetLobbyCreateRequest
    {
        public string appId;
        public int maxSlots;
        public bool ranked;
        public string customAttributes;
    }
}
