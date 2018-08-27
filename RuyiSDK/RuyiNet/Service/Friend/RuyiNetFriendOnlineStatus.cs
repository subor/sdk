namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a player's online status.
    /// </summary>
    public class RuyiNetFriendOnlineStatus
    {
        /// <summary>
        /// Convert from response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        public static implicit operator RuyiNetFriendOnlineStatus(RuyiNetFriendResponseOnlineStatus data)
        {
            return new RuyiNetFriendOnlineStatus()
            {
                UserExists = data.userValid,
                PlayerId = data.profileId,
                IsOnline = data.isOnline,
            };
        }

        /// <summary>
        /// Does the user exist.
        /// </summary>
        public bool UserExists { get; private set; }

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public string PlayerId { get; private set; }

        /// <summary>
        /// Is the player online.
        /// </summary>
        public bool IsOnline { get; private set; }
    }
}
