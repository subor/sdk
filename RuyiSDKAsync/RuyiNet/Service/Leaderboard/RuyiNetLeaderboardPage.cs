using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a single page retrieved from a leaderboard.
    /// </summary>
    public class RuyiNetLeaderboardPage
    {
        /// <summary>
        /// Construct from a Get Global Page response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardPage(RuyiNetGetGlobalLeaderboardPageResponse.Data data)
        {
            Entries = new List<RuyiNetLeaderboardEntry>();
            foreach (var i in data.leaderboard)
            {
                Entries.Add(new RuyiNetLeaderboardEntry(i));
            }

            MoreAfter = data.moreAfter;
            MoreBefore = data.moreBefore;
            TimeBeforeReset = data.timeBeforeReset;
            ServerTime = data.server_time;
        }

        /// <summary>
        /// Construct from a Get Global Page response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardPage(RuyiNetGetGroupSocialLeaderboardResponse.Data data)
        {
            Entries = new List<RuyiNetLeaderboardEntry>();
            foreach (var i in data.leaderboard)
            {
                Entries.Add(new RuyiNetLeaderboardEntry(i));
            }

            TimeBeforeReset = data.timeBeforeReset;
            ServerTime = data.server_time;
        }

        /// <summary>
        /// Construct from a Get Social Leaderboard response.
        /// </summary>
        /// <param name="data">The data from the response</param>
        public RuyiNetLeaderboardPage(RuyiNetGetSocialLeaderboardResponse.Data data)
        {
            Entries = new List<RuyiNetLeaderboardEntry>();
            foreach (var i in data.social_leaderboard)
            {
                Entries.Add(new RuyiNetLeaderboardEntry(i));
            }

            TimeBeforeReset = data.timeBeforeReset;
            ServerTime = data.server_time;
        }

        /// <summary>
        /// The list of entries for this leaderboard page.
        /// </summary>
        public List<RuyiNetLeaderboardEntry> Entries { get; private set; }

        /// <summary>
        /// True if there are more entries after this page.
        /// </summary>
        public bool MoreAfter { get; private set; }

        /// <summary>
        /// True if there are more entries before this page.
        /// </summary>
        public bool MoreBefore { get; private set;  }

        /// <summary>
        /// How long before the next time this leaderboard is reset.
        /// </summary>
        public int TimeBeforeReset { get; private set; }

        /// <summary>
        /// The server time when this leaderboard was retrieved (UNIX timestamp).
        /// </summary>
        public long ServerTime { get; private set; }
    }
}
