using System;

namespace Ruyi
{
    [Serializable]
    class RuyiNetProfileIdRequest
    {
        public string profileId;
    }

    [Serializable]
    class RuyiNetProfileIdsRequest
    {
        public string[] profileIds;
    }
}
