using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    public class FactorGraphTrueSkillCalculator : SkillCalculator
    {
        public FactorGraphTrueSkillCalculator()
            : base(SupportedOptions.PartialPlay | SupportedOptions.PartialUpdate, TeamsRange.AtLeast(2), PlayersRange.AtLeast(1))
        {
        }

        public override IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams, params int[] teamRanks)
        {
            Guard.ArgumentNotNull(gameInfo, "gameInfo");
            ValidateTeamCountAndPlayersCountPerTeam(teams);

            RankSorter.Sort(ref teams, ref teamRanks);

            var factorGraph = new TrueSkillFactorGraph<TPlayer>(gameInfo, teams, teamRanks);
            factorGraph.BuildGraph();
            factorGraph.RunSchedule();

            var probabilityOfOutCome = factorGraph.GetProbabilityOfRanking();

            return factorGraph.GetUpdatedRatings();
        }

        public override double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            var teamAssignmentsList = teams.ToList();
            var skillsMatrix = GetPlayerCovarianceMatrix(teamAssignmentsList);
            var meanVector = GetPlayerMeansVector(teamAssignmentsList);
            var meanVectorTranspose = meanVector.Transpose;

            var playerTeamAssignmentsMatrix = CreatePlayerTeamAssignmentMatrix(teamAssignmentsList, meanVector.Rows);
            var playerTeamAssignmentsMatrixTranspose = playerTeamAssignmentsMatrix.Transpose;

            var betaSquared = gameInfo.Beta * gameInfo.Beta;

            var start = meanVectorTranspose * playerTeamAssignmentsMatrix;
            var aTa = (betaSquared * playerTeamAssignmentsMatrixTranspose) * playerTeamAssignmentsMatrix;
            var aTSA = playerTeamAssignmentsMatrixTranspose * skillsMatrix * playerTeamAssignmentsMatrix;

            var middle = aTa + aTSA;
            var middleInverse = middle.Inverse;

            var end = playerTeamAssignmentsMatrixTranspose * meanVector;

            var expPartMatrix = -0.5 * (start * middleInverse * end);
            var expPart = expPartMatrix.Determinant;

            var sqrtPartNumerator = aTa.Determinant;
            var sqrtPartDenominator = middle.Determinant;
            var sqrtPart = sqrtPartNumerator / sqrtPartDenominator;

            var result = Math.Exp(expPart) * Math.Sqrt(sqrtPart);
            return result;
        }

        private static Matrix GetPlayerCovarianceMatrix<TPlayer>(
            IEnumerable<IDictionary<TPlayer, Rating>> teamAssignmentsList)
        {
            return new DiagonalMatrix(GetPlayerRatingValues(teamAssignmentsList, rating => rating.StandardDeviation * rating.StandardDeviation));
        }

        private static IList<double> GetPlayerRatingValues<TPlayer>(
            IEnumerable<IDictionary<TPlayer, Rating>> teamAssignmentsList,
            Func<Rating, double> playerRatingFunction)
        {
            var playerRatingValues = new List<double>();
            foreach (var currentTeam in teamAssignmentsList)
            {
                foreach (Rating currentRating in currentTeam.Values)
                {
                    playerRatingValues.Add(playerRatingFunction(currentRating));
                }
            }

            return playerRatingValues;
        }

        private static Vector GetPlayerMeansVector<TPlayer>(
            IEnumerable<IDictionary<TPlayer, Rating>> teamAssignmentsList)
        {
            return new Vector(GetPlayerRatingValues(teamAssignmentsList, rating => rating.Mean));
        }

        private static Matrix CreatePlayerTeamAssignmentMatrix<TPlayer>(
            IList<IDictionary<TPlayer, Rating>> teamAssignmentsList, int totalPlayers)
        {
            var playerAssignments = new List<IEnumerable<double>>();
            var totalPreviousPlayers = 0;

            for (var i = 0; i < teamAssignmentsList.Count - 1; ++i)
            {
                var currentTeam = teamAssignmentsList[i];

                var currentRowValues = new List<double>(new double[totalPreviousPlayers]);
                playerAssignments.Add(currentRowValues);

                foreach (var currentRating in currentTeam)
                {
                    currentRowValues.Add(PartialPlay.GetPartialPlayPercentage(currentRating.Key));
                    ++totalPreviousPlayers;
                }

                var nextTeam = teamAssignmentsList[i + 1];
                foreach (var nextTeamPlayerPair in nextTeam)
                {
                    currentRowValues.Add(-1 * PartialPlay.GetPartialPlayPercentage(nextTeamPlayerPair.Key));
                }
            }

            var playerTeamAssignmentsMatrix = new Matrix(totalPlayers, teamAssignmentsList.Count - 1, playerAssignments);
            return playerTeamAssignmentsMatrix;
        }
    }
}
