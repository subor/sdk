namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a player's score on a leaderboard.
    /// </summary>
    public class RuyiNetPlayerScore
    {
        /// <summary>
        /// Construct from response data.
        /// </summary>
        /// <param name="data">The data returned from the response.</param>
        public RuyiNetPlayerScore(RuyiNetGetPlayerScoreResponse.Data.Score data)
        {
            Score = data.score;
            Data = data.data;
            CreatedAt = data.createdAt;
            UpdatedAt = data.updatedAt;
            LeaderboardId = data.leaderboardId;
            VersionId = data.versionId;
        }

        /// <summary>
        /// Construct from response data.
        /// </summary>
        /// <param name="data">The data returned from the response.</param>
        public RuyiNetPlayerScore(RuyiNetGetPlayerScoresFromLeaderboardsResponse.Data.Score data)
        {
            Score = data.score;
            Data = data.data;
            CreatedAt = data.createdAt;
            UpdatedAt = data.updatedAt;
            LeaderboardId = data.leaderboardId;
            VersionId = data.versionId;
        }

        /// <summary>
        /// The player's score.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Data specified by the game developer.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// When this score entry was created.
        /// </summary>
        public long CreatedAt { get; private set; }

        /// <summary>
        /// When this score entry was last updated.
        /// </summary>
        public long UpdatedAt { get; private set; }

        /// <summary>
        /// The ID of the leaderboard this score is an entry for.
        /// </summary>
        public string LeaderboardId { get; private set; }

        /// <summary>
        /// The version of the leaderboard this score is an entry for.
        /// </summary>
        public int VersionId { get; private set; }
    }
}
