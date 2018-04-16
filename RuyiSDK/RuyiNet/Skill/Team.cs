using System.Collections.Generic;
using System.Linq;

namespace Ruyi
{
    /// <summary>
    /// A class to represent a team.
    /// </summary>
    /// <typeparam name="TPlayer">The type used to represent a player.</typeparam>
    public class Team<TPlayer>
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public Team() { }

        /// <summary>
        /// Construct a team with a single player.
        /// </summary>
        /// <param name="player">The player in this team.</param>
        /// <param name="rating">The rating of the player to add.</param>
        public Team(TPlayer player, Rating rating)
        {
            AddPlayer(player, rating);
        }

        /// <summary>
        /// Add a player to the team.
        /// </summary>
        /// <param name="player">The player in this team.</param>
        /// <param name="rating">The rating of the player to add.</param>
        /// <returns>The team after it has had the new player added.</returns>
        public Team<TPlayer> AddPlayer(TPlayer player, Rating rating)
        {
            mPlayerRatings[player] = rating;
            return this;
        }

        /// <summary>
        /// Get the team as a dictionary.
        /// </summary>
        /// <returns>The dictionary listing the players and their ratings.</returns>
        public IDictionary<TPlayer, Rating> AsDictionary()
        {
            return mPlayerRatings;
        }

        private readonly Dictionary<TPlayer, Rating> mPlayerRatings = new Dictionary<TPlayer, Rating>();
    }

    /// <summary>
    /// A default team class that uses the Player class.
    /// </summary>
    public class Team : Team<Player>
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public Team() { }

        /// <summary>
        /// Construct a team with a single player.
        /// </summary>
        /// <param name="player">The player in this team.</param>
        /// <param name="rating">The rating of the player to add.</param>
        public Team(Player player, Rating rating)
            : base(player, rating)
        {
        }
    }

    /// <summary>
    /// Helper class for concatenating teams.
    /// </summary>
    public static class Teams
    {
        /// <summary>
        /// Helper function for concatenating teams.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to represent a player.</typeparam>
        /// <param name="teams">The list of teams to concatenate.</param>
        /// <returns>A dictionary of all the players in one team.</returns>
        public static IEnumerable<IDictionary<TPlayer, Rating>> Concat<TPlayer>(params Team<TPlayer>[] teams)
        {
            return teams.Select(t => t.AsDictionary());
        }
    }
}
