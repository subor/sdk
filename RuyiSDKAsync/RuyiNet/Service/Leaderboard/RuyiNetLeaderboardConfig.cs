using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a leaderboard configuration.
    /// </summary>
    public class RuyiNetLeaderboardConfig
    {
        /// <summary>
        /// Construct from response.
        /// </summary>
        /// <param name="data"></param>
        public RuyiNetLeaderboardConfig(RuyiNetListAllLeaderboardsResponse.Data.LeaderboardInfo data)
        {
            LeaderboardId = data.leaderboardId;
            LeaderboardType = (RuyiNetLeaderboardType)Enum.Parse(typeof(RuyiNetLeaderboardType), data.leaderboardType);
            RotationType = (RuyiNetRotationType)Enum.Parse(typeof(RuyiNetRotationType), data.rotationType);
            ResetAt = data.resetAt;
            CurrentVersionId = data.currentVersionId;
            MaxRetainedCount = data.maxRetainedCount;
            RetainedVersionsCount = data.retainedVersionsCount;
            Data = data.data;
        }

        /// <summary>
        /// The ID of the leaderboard.
        /// </summary>
        public string LeaderboardId { get; private set; }

        /// <summary>
        /// The type of leaderboard.
        /// </summary>
        public RuyiNetLeaderboardType LeaderboardType { get; private set; }

        /// <summary>
        /// When the leaderboard will next be reset.
        /// </summary>
        public long ResetAt { get; private set; }

        /// <summary>
        /// The type of rotation this leaderboard uses.
        /// </summary>
        public RuyiNetRotationType RotationType { get; private set; }

        /// <summary>
        /// The current version of the leaderboard.
        /// </summary>
        public int CurrentVersionId { get; private set; }

        /// <summary>
        /// The maximum number of leaderboards retained.
        /// </summary>
        public int MaxRetainedCount { get; private set; }

        /// <summary>
        /// The actual number of versions currrent retained.
        /// </summary>
        public int RetainedVersionsCount { get; private set; }

        /// <summary>
        /// Custom data specified by the developer.
        /// </summary>
        public string Data { get; private set; }
    }
}
