using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Uses TrueSkill to calculate new ratings for two teams of players.
    /// </summary>
    public class TwoTeamTrueSkillCalculator : SkillCalculator
    {
        /// <inheritdoc/>
        public TwoTeamTrueSkillCalculator()
            : base(SupportedOptions.None, Range<TeamsRange>.Exactly(2), Range<PlayersRange>.AtLeast(1))
        {
        }

        /// <inheritdoc/>
        public override IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(GameInfo gameInfo,
            IEnumerable<IDictionary<TPlayer, Rating>> teams, params int[] teamRanks)
        {
            Guard.ArgumentNotNull(gameInfo, "gameInfo");
            ValidateTeamCountAndPlayersCountPerTeam(teams);

            RankSorter.Sort(ref teams, ref teamRanks);

            var team1 = teams.First();
            var team2 = teams.Last();

            var wasDraw = (teamRanks[0] == teamRanks[1]);

            var results = new Dictionary<TPlayer, Rating>();

            UpdatePlayerRatings(gameInfo, results, team1, team2,
                wasDraw ? PairwiseComparison.Draw : PairwiseComparison.Win);

            UpdatePlayerRatings(gameInfo, results, team2, team1,
                wasDraw ? PairwiseComparison.Draw : PairwiseComparison.Lose);

            return results;
        }

        /// <inheritdoc/>
        public override double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            Guard.ArgumentNotNull(gameInfo, "gameInfo");
            ValidateTeamCountAndPlayersCountPerTeam(teams);

            var team1 = teams.First().Values;
            var team1Count = team1.Count();

            var team2 = teams.Last().Values;
            var team2Count = team2.Count();

            var totalPlayers = team1Count + team2Count;

            var betaSquared = gameInfo.Beta * gameInfo.Beta;

            var team1MeanSum = team1.Sum(r => r.Mean);
            var team1StdDevSquared = team1.Sum(r => r.StandardDeviation * r.StandardDeviation);

            var team2MeanSum = team2.Sum(r => r.Mean);
            var team2SigmaSquared = team2.Sum(r => r.StandardDeviation * r.StandardDeviation);

            var meanSumDiff = team1MeanSum - team2MeanSum;
            var denominator = totalPlayers * betaSquared + team1StdDevSquared + team2SigmaSquared;

            var sqrtPart = Math.Sqrt((totalPlayers * betaSquared) / denominator);
            var expPart = Math.Exp((-1 * (meanSumDiff * meanSumDiff)) / (2 * denominator));

            return expPart * sqrtPart;
        }

        private static void UpdatePlayerRatings<TPlayer>(GameInfo gameInfo,
            IDictionary<TPlayer, Rating> newPlayerRatings,
            IDictionary<TPlayer, Rating> selfTeam,
            IDictionary<TPlayer, Rating> otherTeam,
            PairwiseComparison selfToOtherTeamComparison)
        {
            var drawMargin = DrawMargin.GetDrawMarginFromDrawProbability(gameInfo.DrawProbability, gameInfo.Beta);
            var betaSquared = gameInfo.Beta * gameInfo.Beta;
            var tauSquared = gameInfo.DynamicsFactor * gameInfo.DynamicsFactor;

            var totalPlayers = selfTeam.Count() + otherTeam.Count();

            var selfMeanSum = selfTeam.Values.Sum(r => r.Mean);
            var otherTeamMeanSum = otherTeam.Values.Sum(r => r.Mean);

            var c = Math.Sqrt(selfTeam.Values.Sum(r => r.StandardDeviation * r.StandardDeviation) +
                otherTeam.Values.Sum(r => r.StandardDeviation * r.StandardDeviation) +
                totalPlayers * betaSquared);

            var winningMean = selfMeanSum;
            var losingMean = otherTeamMeanSum;

            if (selfToOtherTeamComparison == PairwiseComparison.Lose)
            {
                winningMean = otherTeamMeanSum;
                losingMean = selfMeanSum;
            }

            var meanDelta = winningMean - losingMean;

            double v, w, rankMultiplier;

            if (selfToOtherTeamComparison != PairwiseComparison.Draw)
            {
                v = TruncatedGaussianCorrectionFunctions.VExceedsMargin(meanDelta, drawMargin, c);
                w = TruncatedGaussianCorrectionFunctions.WExceedsMargin(meanDelta, drawMargin, c);
                rankMultiplier = (int)selfToOtherTeamComparison;
            }
            else
            {
                v = TruncatedGaussianCorrectionFunctions.VWithinMargin(meanDelta, drawMargin, c);
                w = TruncatedGaussianCorrectionFunctions.WWithinMargin(meanDelta, drawMargin, c);
                rankMultiplier = 1;
            }

            foreach (var teamPlayerRatingPair in selfTeam)
            {
                Rating previousPlayerRating = teamPlayerRatingPair.Value;

                var meanMultiplier = ((previousPlayerRating.StandardDeviation * previousPlayerRating.StandardDeviation) + tauSquared) / c;
                var stdDevMultiplier = ((previousPlayerRating.StandardDeviation * previousPlayerRating.StandardDeviation) + tauSquared) / (c * c);

                var playerMeanDelta = rankMultiplier * meanMultiplier * v;

                var newMean = previousPlayerRating.Mean + playerMeanDelta;
                var newStdDev = Math.Sqrt(((previousPlayerRating.StandardDeviation * previousPlayerRating.StandardDeviation) + tauSquared) * (1 - w * stdDevMultiplier));

                newPlayerRatings[teamPlayerRatingPair.Key] = new Rating(newMean, newStdDev);
            }
        }
    }
}
