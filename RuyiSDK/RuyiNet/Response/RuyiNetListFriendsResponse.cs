using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// The response after a friend list is requested.
    /// </summary>
    [Serializable]
    public class RuyiNetListFriendsResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The response from the server-side script.
            /// </summary>
            [Serializable]
            public class Response
            {
                /// <summary>
                /// The details of a specific friend.
                /// </summary>
                [Serializable]
                public class Friend
                {
                    /// <summary>
                    /// The ID of the player.
                    /// </summary>
                    public string playerId;

                    /// <summary>
                    /// The username of the player.
                    /// </summary>
                    public string name;

                    /// <summary>
                    /// The URL of the player's profile picture.
                    /// </summary>
                    public string pictureUrl;

                    /// <summary>
                    /// The summary data of the player.
                    /// </summary>
                    public RuyiNetSummaryFriendData summaryFriendData;
                }

                /// <summary>
                /// The list of friends.
                /// </summary>
                public Friend[] friends;

                /// <summary>
                /// Timestamp of when the list was retrieved.
                /// </summary>
                public long server_time;
            }

            /// <summary>
            /// The actual response.
            /// </summary>
            public Response response;

            /// <summary>
            /// Whether or not the server-side script ran successfully.
            /// </summary>
            public bool success;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status code of the returned data.
        /// </summary>
        public int status;
    }
}
