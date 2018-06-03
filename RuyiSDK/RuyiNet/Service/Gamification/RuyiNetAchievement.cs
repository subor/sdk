namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents an achievement in RuyiNet
    /// </summary>
    public class RuyiNetAchievement
    {
        /// <summary>
        /// Construct from an achievement response.
        /// </summary>
        /// <param name="achievement">An achievement returned from a response.</param>
        public RuyiNetAchievement(RuyiNetAchievementResponse.Data.Achievement achievement)
        {
            GameId = achievement.gameId;
            AchievementId = achievement.achievementId;
            Title = achievement.title;
            Description = achievement.description;
            InvisibleUntilEarned = achievement.invisibleUntilEarned;
            ImageUrl = achievement.imageUrl;
            ExtraData = achievement.extraData;
            XpAwarded = achievement.xpAwarded;
            CoinAwarded = achievement.coinAwarded;

            if (achievement.status == "NOT_AWARDED")
            {
                Status = RuyiNetAchievementStatus.NOT_AWARDED;
            }
            else if (achievement.status == "AWARDED")
            {
                Status = RuyiNetAchievementStatus.AWARDED;
            }
            else
            {
                Status = RuyiNetAchievementStatus.UNKNOWN;
            }
        }

        /// <summary>
        /// The ID of the game this achievement belongs to.
        /// </summary>
        public string GameId { get; private set; }

        /// <summary>
        /// The ID of the achievement.
        /// </summary>
        public string AchievementId { get; private set; }

        /// <summary>
        /// The achievement's title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// A description of the achievement.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Whether or not the achievement is invisible until it's earned.
        /// </summary>
        public bool InvisibleUntilEarned { get; private set; }

        /// <summary>
        /// The URL of the image related to this achievement.
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// Any extra data attached by the developer.
        /// </summary>
        public string ExtraData { get; private set; }

        /// <summary>
        /// The XP awarded when this achievement is gained.
        /// </summary>
        public int XpAwarded { get; private set; }

        /// <summary>
        /// The amount of coin awarded when this achievement is gained.
        /// </summary>
        public int CoinAwarded { get; private set; }
        
        /// <summary>
        /// Whether or not the current player has earned this achievement.
        /// </summary>
        public RuyiNetAchievementStatus Status { get; private set; }
    }
}
