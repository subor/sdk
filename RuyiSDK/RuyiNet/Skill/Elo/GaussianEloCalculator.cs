using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Calculates ELO ratings using a Gaussian distribution.
    /// </summary>
    public class GaussianEloCalculator : TwoPlayerEloCalculator
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public GaussianEloCalculator()
            : base(StableKFactor)
        {
        }

        /// <summary>
        /// Get the player win probability based on the player's ratings.
        /// </summary>
        /// <param name="gameInfo">The game info we are calculating for.</param>
        /// <param name="playerRating">This player's rating.</param>
        /// <param name="opponentRating">The opponent's rating.</param>
        /// <returns>The chance that this player wins the match.</returns>
        protected override double GetPlayerWinProbability(GameInfo gameInfo, double playerRating, double opponentRating)
        {
            double ratingDifference = playerRating - opponentRating;
            return GaussianDistribution.CumulativeTo(ratingDifference / (Sqrt2 * gameInfo.Beta));
        }

        private static readonly double Sqrt2 = Math.Sqrt(2);
        private static readonly KFactor StableKFactor = new KFactor(24);
    }
}
