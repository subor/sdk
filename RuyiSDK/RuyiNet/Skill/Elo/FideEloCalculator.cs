using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Calculates ELO ratings using Fide.
    /// </summary>
    public class FideEloCalculator : TwoPlayerEloCalculator
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public FideEloCalculator()
            : this(new FideKFactor())
        {
        }

        /// <summary>
        /// Construct with a custom k-factor.
        /// </summary>
        /// <param name="kFactor">The custom k-factor to use.</param>
        public FideEloCalculator(FideKFactor kFactor)
            : base(kFactor)
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
            double ratingDifference = opponentRating - playerRating;
            return 1.0 / (1.0 + Math.Pow(10.0, ratingDifference / (2 * gameInfo.Beta)));
        }
    }
}
