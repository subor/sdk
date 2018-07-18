using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents the summary data for a friend.
    /// </summary>
    public class RuyiNetFriendSummaryData
    {
        /// <summary>
        /// Convert from response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        public static implicit operator RuyiNetFriendSummaryData(RuyiNetFriendResponseSummaryData data)
        {
            return new RuyiNetFriendSummaryData()
            {
                Name = data.profileName,
                PlayerId = data.profileId,
                PictureUrl = data.pictureUrl,
                Data = data.summaryFriendData,
                Email = data.email,
            };
        }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public string PlayerId { get; private set; }

        /// <summary>
        /// The resource location of the player's profile picture.
        /// </summary>
        public string PictureUrl { get; private set; }

        /// <summary>
        /// Custom data attached to the player.
        /// </summary>
        public Dictionary<string, object> Data { get; private set; }

        /// <summary>
        /// The email address of the player.
        /// </summary>
        public string Email { get; private set; }
    }
}
