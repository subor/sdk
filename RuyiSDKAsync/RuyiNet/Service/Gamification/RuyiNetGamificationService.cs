using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<RuyiNetAchievement> AwardAchievement(int index, string achievementId)
        {
            List<string> achievementIds = new List<string>() { achievementId };
            var resp = await mClient.BCService.Gamification_AwardAchievementsAsync(achievementIds, index, token);
            var response = mClient.Process<RuyiNetAchievementResponse>(resp);
            if (response.status == RuyiNetHttpStatus.OK)
            {
                var achievements = response.data.achievements;
                if (achievements.Length == 0)
                {
                    return new RuyiNetAchievement(achievements[0]);
                }
            }
            return null;
        }

        /// <summary>
        /// Award multiple achievements to the player.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="achievementIds">The ID of the achievement to unlock.</param>
        public async Task<List<RuyiNetAchievement>> AwardAchievements(int index, List<string> achievementIds)
        {
            var resp = await mClient.BCService.Gamification_AwardAchievementsAsync(achievementIds, index, token);
            var response = mClient.Process<RuyiNetAchievementResponse>(resp);
            if (response.status == RuyiNetHttpStatus.OK)
            {
                List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                var achievementData = response.data.achievements;

                foreach (var i in achievementData)
                {
                    achievements.Add(new RuyiNetAchievement(i));
                }

                return achievements;
            }
            return null;
        }

        /// <summary>
        /// Read all the achievements the current player has earned.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
        public async Task<List<RuyiNetAchievement>> ReadAchievedAchievements(int index, bool includeMetaData)
        {
            var resp = await mClient.BCService.Gamification_ReadAchievedAchievementsAsync(includeMetaData, index, token);
            var response = mClient.Process<RuyiNetAchievementResponse>(resp);
            if (response.status == RuyiNetHttpStatus.OK)
            {
                List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                var achievementData = response.data.achievements;

                foreach (var i in achievementData)
                {
                    achievements.Add(new RuyiNetAchievement(i));
                }

                return achievements;
            }
            return null;
        }

        /// <summary>
        /// Read the achievement data for the current game.
        /// </summary>
        /// <param name="index">The index of the user.</param>
        /// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
        public async Task<List<RuyiNetAchievement>> ReadAchievements(int index, bool includeMetaData)
        {
            var resp = await mClient.BCService.Gamification_ReadAchievementsAsync(includeMetaData, index, token);
            var response = mClient.Process<RuyiNetAchievementResponse>(resp);
            if (response.status == RuyiNetHttpStatus.OK)
            {
                List<RuyiNetAchievement> achievements = new List<RuyiNetAchievement>();
                var achievementData = response.data.achievements;

                foreach (var i in achievementData)
                {
                    achievements.Add(new RuyiNetAchievement(i));
                }

                return achievements;
            }
            return null;
        }
    }
}