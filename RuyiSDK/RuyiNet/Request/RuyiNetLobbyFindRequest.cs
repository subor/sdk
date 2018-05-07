using System;

namespace Ruyi.SDK.Cloud
{
    [Serializable]
    class RuyiNetLobbyFindRequest
    {
        public int numResults;
        public string appId;
        public int freeSlots;
        public bool ranked;
        public string searchCriteria;
    }
}
