using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// An ELO Calculator specifically for two player matches.
    /// </summary>
    public abstract class TwoPlayerEloCalculator : SkillCalculator
    {
        /// <summary>
        /// Calculates the new ELO ratings for players based on the results of a match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players (in this case should always be two teams with
        ///                     one player each).</param>
        /// <param name="teamRanks">The ranks of the teams (i.e. which player came first and which player came
        ///                         second).</param>
        /// <returns>A list of players and their new rating</returns>
        public override IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(
            GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams,
            params int[] teamRanks)
        {
            ValidateTeamCountAndPlayersCountPerTeam(teams);
            RankSorter.Sort(ref teams, ref teamRanks);

            var result = new Dictionary<TPlayer, Rating>();
            var isDraw = (teamRanks[0] == teamRanks[1]);

            var player1 = teams.First().First();
            var player2 = teams.Last().First();

            var player1Rating = player1.Value.Mean;
            var player2Rating = player2.Value.Mean;

            result[player1.Key] = CalculateNewRating(gameInfo, player1Rating, player2Rating, isDraw ? PairwiseComparison.Draw : PairwiseComparison.Win);
            result[player2.Key] = CalculateNewRating(gameInfo, player2Rating, player1Rating, isDraw ? PairwiseComparison.Draw : PairwiseComparison.Lose);

            return result;
        }

        /// <summary>
        /// Calculate the quality of the match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players (in this case should always be two teams with
        ///                     one player each).</param>
        /// <returns>The quality of the match specified.</returns>
        public override double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            ValidateTeamCountAndPlayersCountPerTeam(teams);
            var player1Rating = teams.First().First().Value.Mean;
            var player2Rating = teams.Last().First().Value.Mean;
            var ratingDifference = player1Rating - player2Rating;

            var deltaFrom50Percent = Math.Abs(GetPlayerWinProbability(gameInfo, player1Rating, player2Rating) - 0.5);
            return (0.5 - deltaFrom50Percent) * 2.0;
        }

        /// <summary>
        /// Construct a two-player ELO Calculator.
        /// </summary>
        /// <param name="kFactor">The K-Factor used in ELO calculations.</param>
        protected TwoPlayerEloCalculator(KFactor kFactor)
            : base(SupportedOptions.None, TeamsRange.Exactly(2), PlayersRange.Exactly(1))
        {
            mKFactor = kFactor;
        }

        /// <summary>
        /// Calculate a new ELO rating for the specified player.
        /// </summary>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="selfRating">The rating of the player we are calculating for.</param>
        /// <param name="opponentRating">The rating of the opposing player.</param>
        /// <param name="selfToOpponentComparison">The result of the match for the player (win, lose, draw).</param>
        /// <returns>A new ELO rating for the player.</returns>
        protected virtual EloRating CalculateNewRating(GameInfo gameInfo, double selfRating, double opponentRating, PairwiseComparison selfToOpponentComparison)
        {
            var expectedProbability = GetPlayerWinProbability(gameInfo, selfRating, opponentRating);
            var actualProbability = GetScoreFromComparison(selfToOpponentComparison);
            var k = mKFactor.GetValueForRating(selfRating);
            var ratingChange = k * (actualProbability - expectedProbability);
            var newRating = selfRating + ratingChange;

            return new EloRating(newRating);
        }

        /// <summary>
        /// Calculate the chance of the player winning.
        /// </summary>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="playerRating">The rating of the player we are calculating for.</param>
        /// <param name="opponentRating">The rating of the opposing player.</param>
        /// <returns>The chance of the player winning.</returns>
        protected abstract double GetPlayerWinProbability(GameInfo gameInfo, double playerRating, double opponentRating);

        /// <summary>
        /// The K-Factor we are using in ELO calculations.
        /// </summary>
        protected readonly KFactor mKFactor;

        private static double GetScoreFromComparison(PairwiseComparison comparison)
        {
            switch (comparison)
            {
                case PairwiseComparison.Win:
                    return 1;

                case PairwiseComparison.Draw:
                    return 0.5;

                case PairwiseComparison.Lose:
                    return 0;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
