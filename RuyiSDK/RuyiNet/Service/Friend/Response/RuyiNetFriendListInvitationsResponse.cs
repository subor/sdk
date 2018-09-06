using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response recieved from a List Invitations request.
    /// </summary>
    [Serializable]
    public class RuyiNetFriendListInvitationsResponse
    {
        /// <summary>
        /// Represents the response data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// A list of invitations.
            /// </summary>
            public RuyiNetFriendResponseInvite[] friendInvitations;
        }


        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
