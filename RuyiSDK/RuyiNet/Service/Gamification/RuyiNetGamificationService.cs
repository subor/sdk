using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Provides gamification services to a game.
    /// </summary>
    public class RuyiNetGamificationService : RuyiNetService
    {
        internal RuyiNetGamificationService(RuyiNetClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Award a single achievement to the player.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="achievementId">The ID of the achievement to unlock.</param>
        /// <param name="callback">Called when the achievement is unlocked.</param>
        public void AwardAchievement(int index, string achievementId, Action<RuyiNetAchievement> callback)
        {
            EnqueueTask(() =>
            {
                List<string> achievementIds = new List<string>() { achievementId };
                return mClient.BCService.Gamification_AwardAchievements(achievementIds, index);
            }, (RuyiNetAchievementResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var achievements = response.data.achievements;
                        if (achievements.Length == 0)
                        {
                            callback(new RuyiNetAchievement(achievements[0]));
                            return;
                        }
                    }

                    callback(null);
                }
            });
        }

        /// <summary>
        /// Award multiple achievements to the player.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="achievementIds">The ID of the achievement to unlock.</param>
        /// <param name="callback">Called when the achievement is unlocked.</param>
        public void AwardAchievements(int index, List<string> achievementIds, Action<List<RuyiNetAchievement>> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Gamification_AwardAchievements(achievementIds, index);
            }, (RuyiNetAchievementResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                        var achievementData = response.data.achievements;

                        foreach (var i in achievementData)
                        {
                            achievements.Add(new RuyiNetAchievement(i));
                        }

                        callback(achievements);
                        return;
                    }

                    callback(null);
                }
            });
        }

        /// <summary>
        /// Read all the achievements the current player has earned.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
        /// <param name="callback">Called when the achievement is unlocked.</param>
        public void ReadAchievedAchievements(int index, bool includeMetaData, Action<List<RuyiNetAchievement>> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Gamification_ReadAchievedAchievements(includeMetaData, index);
            }, (RuyiNetAchievementResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                        var achievementData = response.data.achievements;

                        foreach (var i in achievementData)
                        {
                            achievements.Add(new RuyiNetAchievement(i));
                        }

                        callback(achievements);
                        return;
                    }

                    callback(null);
                }
            });
        }

        /// <summary>
        /// Read the achievement data for the current game.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
        /// <param name="callback">Called when the achievement is unlocked.</param>
        public void ReadAchievements(int index, bool includeMetaData, Action<List<RuyiNetAchievement>> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Gamification_ReadAchievements(includeMetaData, index);
            }, (RuyiNetAchievementResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                        var achievementData = response.data.achievements;

                        foreach (var i in achievementData)
                        {
                            achievements.Add(new RuyiNetAchievement(i));
                        }

                        callback(achievements);
                        return;
                    }

                    callback(null);
                }
            });
        }
    }
}