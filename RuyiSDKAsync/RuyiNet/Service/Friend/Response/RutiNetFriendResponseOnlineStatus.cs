using System;
using System.Collections.Generic;
using System.Text;

namespace Ruyi.SDK.RuyiNet.Service.Friend.Response
{
    [Serializable]
    public class RutiNetFriendResponseOnlineStatus
    {
        public bool userValid;
        public string profileId;
        public bool isOnline;
    }
}
