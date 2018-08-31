using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response recieved from an achievemet request (gamification service).
    /// </summary>
    public class RuyiNetAchievementResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// Represents an achievement
            /// </summary>
            [Serializable]
            public class Achievement
            {
                /// <summary>
                /// The ID of the achievement.
                /// </summary>
                public string achievementId;

                /// <summary>
                /// Whether or not the current player has earned this achievement.
                /// </summary>
                public string status;

                /// <summary>
                /// The ID of the game this achievement belongs to.
                /// </summary>
                public string gameId;

                /// <summary>
                /// The achievement's title.
                /// </summary>
                public string title;

                /// <summary>
                /// A description of the achievement.
                /// </summary>
                public string description;

                /// <summary>
                /// Whether or not the achievement is invisible until it's earned.
                /// </summary>
                public bool invisibleUntilEarned;

                /// <summary>
                /// The URL of the image related to this achievement.
                /// </summary>
                public string imageUrl;

                /// <summary>
                /// Any extra data attached by the developer.
                /// </summary>
                public string extraData;

                /// <summary>
                /// The XP awarded when this achievement is gained.
                /// </summary>
                public int xpAwarded;

                /// <summary>
                /// The amount of coin awarded when this achievement is gained.
                /// </summary>
                public int coinAwarded;
            }

            public Achievement[] achievements;
        }

        /// <summary>
        /// The data returned with the response.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }
}
