using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi
{
    /// <summary>
    /// True Skill calculator specialised for two players.
    /// </summary>
    public class TwoPlayerTrueSkillCalculator : SkillCalculator
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public TwoPlayerTrueSkillCalculator()
            : base(SupportedOptions.None, Range<TeamsRange>.Exactly(2), Range<PlayersRange>.Exactly(1))
        {
        }

        /// <inheritdoc/>
        public override IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(GameInfo gameInfo,
            IEnumerable<IDictionary<TPlayer, Rating>> teams, params int[] teamRanks)
        {
            Guard.ArgumentNotNull(gameInfo, "gameInfo");
            ValidateTeamCountAndPlayersCountPerTeam(teams);

            RankSorter.Sort(ref teams, ref teamRanks);

            List<IDictionary<TPlayer, Rating>> teamList = teams.ToList();

            IDictionary<TPlayer, Rating> winningTeam = teamList[0];
            TPlayer winner = winningTeam.Keys.First();
            Rating winnerPreviousRating = winningTeam[winner];

            IDictionary<TPlayer, Rating> losingTeam = teamList[1];
            TPlayer loser = losingTeam.Keys.First();
            Rating loserPreviousRating = losingTeam[loser];

            var wasDraw = (teamRanks[0] == teamRanks[1]);

            var results = new Dictionary<TPlayer, Rating>
            {
                [winner] = CalculateNewRating(gameInfo, winnerPreviousRating, loserPreviousRating,
                    wasDraw ? PairwiseComparison.Draw : PairwiseComparison.Win),

                [loser] = CalculateNewRating(gameInfo, loserPreviousRating, winnerPreviousRating,
                    wasDraw ? PairwiseComparison.Draw : PairwiseComparison.Lose)
            };

            return results;
        }

        /// <inheritdoc/>
        public override double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            Guard.ArgumentNotNull(gameInfo, "gameInfo");
            ValidateTeamCountAndPlayersCountPerTeam(teams);

            Rating player1Rating = teams.First().Values.First();
            Rating player2Rating = teams.Last().Values.First();

            var betaSquared = (gameInfo.Beta * gameInfo.Beta);
            var player1SigmaSquared = (player1Rating.StandardDeviation * player1Rating.StandardDeviation);
            var player2SigmaSquared = (player2Rating.StandardDeviation * player2Rating.StandardDeviation);

            var sqrtPart = Math.Sqrt((2 * betaSquared) /
                (2 * betaSquared + player1SigmaSquared + player2SigmaSquared));

            var meanDifference = player1Rating.Mean - player2Rating.Mean;

            var expPart = Math.Exp((-1 * (meanDifference * meanDifference)) /
                (2 * (2 * betaSquared + player1SigmaSquared + player2SigmaSquared)));

            return sqrtPart * expPart;
        }

        private static Rating CalculateNewRating(GameInfo gameInfo, Rating selfRating,
            Rating opponentRating, PairwiseComparison comparison)
        {
            var drawMargin = DrawMargin.GetDrawMarginFromDrawProbability(gameInfo.DrawProbability, gameInfo.Beta);

            var c = Math.Sqrt((selfRating.StandardDeviation * selfRating.StandardDeviation) +
                (opponentRating.StandardDeviation * opponentRating.StandardDeviation) +
                2 * (gameInfo.Beta * gameInfo.Beta));

            var winningMean = selfRating.Mean;
            var losingMean = opponentRating.Mean;

            if (comparison == PairwiseComparison.Lose)
            {
                winningMean = opponentRating.Mean;
                losingMean = selfRating.Mean;
            }

            var meanDelta = winningMean - losingMean;

            double v;
            double w;
            double rankMultiplier;

            if (comparison != PairwiseComparison.Draw)
            {
                v = TruncatedGaussianCorrectionFunctions.VExceedsMargin(meanDelta, drawMargin, c);
                w = TruncatedGaussianCorrectionFunctions.WExceedsMargin(meanDelta, drawMargin, c);
                rankMultiplier = (int)comparison;
            }
            else
            {
                v = TruncatedGaussianCorrectionFunctions.VWithinMargin(meanDelta, drawMargin, c);
                w = TruncatedGaussianCorrectionFunctions.WWithinMargin(meanDelta, drawMargin, c);
                rankMultiplier = 1;
            }

            var meanMultiplier = ((selfRating.StandardDeviation * selfRating.StandardDeviation) +
                (gameInfo.DynamicsFactor * gameInfo.DynamicsFactor)) / c;

            var varianceWithDynamics = (selfRating.StandardDeviation * selfRating.StandardDeviation) +
                (gameInfo.DynamicsFactor * gameInfo.DynamicsFactor);

            var stdDevMultiplier = varianceWithDynamics / (c * c);

            var newMean = selfRating.Mean + (rankMultiplier * meanMultiplier * v);
            var newStdDev = Math.Sqrt(varianceWithDynamics * (1 - w * stdDevMultiplier));

            return new Rating(newMean, newStdDev);
        }
    }
} 
