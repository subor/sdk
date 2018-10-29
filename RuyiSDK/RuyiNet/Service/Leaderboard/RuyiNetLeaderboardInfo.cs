using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a leaderboard on RuyiNet.
    /// </summary>
    public class RuyiNetLeaderboardInfo
    {
        /// <summary>
        /// Construct from response data.
        /// </summary>
        /// <param name="data">The data returned from the response.</param>
        public RuyiNetLeaderboardInfo(RuyiNetGetGlobalLeaderboardVersionsResponse.Data data)
        {
            LeaderboardId = data.leaderboardId;
            LeaderboardType = (RuyiNetLeaderboardType)Enum.Parse(typeof(RuyiNetLeaderboardType), data.leaderboardType);
            RotationType = (RuyiNetRotationType)Enum.Parse(typeof(RuyiNetRotationType), data.rotationType);
            RetainedCount = data.retainedCount;

            Versions = new List<RuyiNetLeaderboardVersionInfo>();
            foreach (var i in data.versions)
            {
                Versions.Add(new RuyiNetLeaderboardVersionInfo(i));
            }
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
        /// The type of leaderboard rotation.
        /// </summary>
        public RuyiNetRotationType RotationType { get; private set; }

        /// <summary>
        /// The number of versions retained.
        /// </summary>
        public int RetainedCount { get; private set; }

        /// <summary>
        /// A list of versions currently retained.
        /// </summary>
        public List<RuyiNetLeaderboardVersionInfo> Versions { get; private set; }
    }
}
