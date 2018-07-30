namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a single leaderboard entry.
    /// </summary>
    public class RuyiNetLeaderboardEntry
    {
        /// <summary>
        /// Construct from a Get Global Page response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardEntry(RuyiNetGetGlobalLeaderboardPageResponse.Data.LeaderboardEntry data)
        {
            PlayerId = data.playerId;
            Score = data.score;
            Data = data.data;
            CreatedAt = data.createdAt;
            UpdatedAt = data.updatedAt;
            Index = data.index;
            Rank = data.rank;
            Name = data.name;
            PictureUrl = data.pictureUrl;
        }

        /// <summary>
        /// Construct from a Get Group Social Leaderboard response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardEntry(RuyiNetGetGroupSocialLeaderboardResponse.Data.LeaderboardEntry data)
        {
            PlayerId = data.playerId;
            Score = data.score;
            Data = data.data;
            CreatedAt = data.createdAt;
            UpdatedAt = data.updatedAt;
            Index = data.index;
            Rank = data.rank;
            Name = data.playerName;
            PictureUrl = data.pictureUrl;
        }

        /// <summary>
        /// Construct from a Get Social Leaderboard response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardEntry(RuyiNetGetSocialLeaderboardResponse.Data.LeaderboardEntry data)
        {
            PlayerId = data.playerId;
            Score = data.score;
            Data = data.otherData;
            CreatedAt = data.createdAt;
            UpdatedAt = data.updatedAt;
            Name = data.name;
            PictureUrl = data.pictureUrl;
        }

        /// <summary>
        /// The ID of the player this entry represents.
        /// </summary>
        public string PlayerId { get; private set; }

        /// <summary>
        /// The latest score for the player.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Extra data provided by the developer, if any.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// When this entry was created (UNIX timestamp).
        /// </summary>
        public long CreatedAt { get; private set; }

        /// <summary>
        /// When this entry was last updated (UNIX timestamp).
        /// </summary>
        public long UpdatedAt { get; private set; }

        /// <summary>
        /// The index of this entry.
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// The overall rank of the player on this leaderboard.
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        /// The display name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The URL of the player's profile picture.
        /// </summary>
        public string PictureUrl { get; private set; }
    }
}
