using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// The summary data of the player.
    /// </summary>
    [Serializable]
    public class RuyiNetSummaryFriendData
    {
        /// <summary>
        /// The player's gender.
        /// </summary>
        public string gender;

        /// <summary>
        /// The player's date of birth.
        /// </summary>
        public string dob;

        /// <summary>
        /// The location of the player.
        /// </summary>
        public string location;
    }

    /// <summary>
    /// A profile that can be returned from Ruyi Net operations.
    /// </summary>
    [Serializable]
    public class RuyiNetProfile
    {
        /// <summary>
        /// The username of the player.
        /// </summary>
        public string profileName;

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public string profileId;

        /// <summary>
        /// The URL of the player's profile picture.
        /// </summary>
        public string pictureUrl;

        /// <summary>
        /// The email of the player.
        /// </summary>
        public string email;

        /// <summary>
        /// Whether or not this player is a friend.
        /// </summary>
        public bool friend;

        /// <summary>
        /// The summary data of the player.
        /// </summary>
        public RuyiNetSummaryFriendData summaryFriendData;
    }

    /// <summary>
    /// The response after a single profile is requested.
    /// </summary>
    [Serializable]
    public class RuyiNetGetProfileResponse
    {
        /// <summary>
        /// The data contained in the response.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The profile returned in the response.
            /// </summary>
            public RuyiNetProfile response;

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

    /// <summary>
    /// The response after a list of profiles are requested.
    /// </summary>
    [Serializable]
    public class RuyiNetGetProfilesResponse
    {
        /// <summary>
        /// The data contained in the response.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The profiles returned in the response.
            /// </summary>
            public RuyiNetProfile[] response;

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
