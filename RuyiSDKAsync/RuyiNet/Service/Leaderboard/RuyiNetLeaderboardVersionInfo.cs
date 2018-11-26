namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a leaderboard version.
    /// </summary>
    public class RuyiNetLeaderboardVersionInfo
    {
        /// <summary>
        /// Construct from response data.
        /// </summary>
        /// <param name="data">The data from the response.</param>
        public RuyiNetLeaderboardVersionInfo(RuyiNetGetGlobalLeaderboardVersionsResponse.Data.VersionInfo data)
        {
            VersionId = data.versionId;
            StartingAt = data.startingAt;
            EndingAt = data.endingAt;
        }

        /// <summary>
        /// The ID of this version.
        /// </summary>
        public int VersionId { get; private set; }

        /// <summary>
        /// The time this version starts.
        /// </summary>
        public long StartingAt { get; private set; }

        /// <summary>
        /// The time this version ends.
        /// </summary>
        public long EndingAt { get; private set; }
    }
}
