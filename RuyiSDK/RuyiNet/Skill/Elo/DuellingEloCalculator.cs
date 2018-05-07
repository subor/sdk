using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// An ELO calculator for games with more than two teams / players.
    /// </summary>
    public class DuellingEloCalculator : SkillCalculator
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        /// <param name="twoPlayerEloCalculator">The two player calculator to base this off.</param>
        public DuellingEloCalculator(TwoPlayerEloCalculator twoPlayerEloCalculator)
            : base(SupportedOptions.None, TeamsRange.AtLeast(2), PlayersRange.AtLeast(1))
        {
            mTwoPlayerEloCalculator = twoPlayerEloCalculator;
        }

        /// <summary>
        /// Calculates the new ELO ratings for players based on the results of a match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players.</param>
        /// <param name="teamRanks">The ranks of the teams.</param>
        /// <returns>A list of players and their new rating.</returns>
        public override IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams, params int[] teamRanks)
        {
            ValidateTeamCountAndPlayersCountPerTeam(teams);
            RankSorter.Sort(ref teams, ref teamRanks);

            var teamsList = teams.ToList();

            var deltas = new Dictionary<TPlayer, IDictionary<TPlayer, double>>();

            for (var iCurrentTeam = 0; iCurrentTeam < teamsList.Count; ++iCurrentTeam)
            {
                for (var iOtherTeam = 0; iOtherTeam < teamsList.Count; ++iOtherTeam)
                {
                    if (iOtherTeam == iCurrentTeam)
                    {
                        continue;
                    }

                    var currentTeam = teamsList[iCurrentTeam];
                    var otherTeam = teamsList[iOtherTeam];

                    var comparison = (PairwiseComparison)Math.Sign(teamRanks[iOtherTeam] - teamRanks[iCurrentTeam]);

                    foreach (var currentTeamPlayerRatingPair in currentTeam)
                    {
                        foreach (var otherTeamPlayerRatingPair in otherTeam)
                        {
                            UpdateDuels(gameInfo, deltas, currentTeamPlayerRatingPair.Key, 
                                currentTeamPlayerRatingPair.Value, otherTeamPlayerRatingPair.Key,
                                otherTeamPlayerRatingPair.Value, comparison);
                        }
                    }
                }
            }

            var result = new Dictionary<TPlayer, Rating>();
            foreach (var currentTeam in teamsList)
            {
                foreach (var currentTeamPlayerPair in currentTeam)
                {
                    var currentPlayerAverageDuellingDelta = deltas[currentTeamPlayerPair.Key].Values.Average();
                    result[currentTeamPlayerPair.Key] = new EloRating(currentTeamPlayerPair.Value.Mean + currentPlayerAverageDuellingDelta);
                }
            }

            return result;
        }

        /// <summary>
        /// Calculate the quality of the match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players.</param>
        /// <returns>The quality of the match specified.</returns>
        public override double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            double minQuality = 1.0;

            var teamList = teams.ToList();

            for (var iCurrentTeam = 0; iCurrentTeam < teamList.Count; ++iCurrentTeam)
            {
                var currentTeamAverageRating = new EloRating(teamList[iCurrentTeam].Values.Average(r => r.Mean));
                var currentTeam = new Team(new Player(iCurrentTeam), currentTeamAverageRating);

                for (var iOtherTeam = iCurrentTeam + 1; iOtherTeam < teamList.Count; ++iOtherTeam)
                {
                    EloRating otherTeamAverageRating = new EloRating(teamList[iOtherTeam].Values.Average(r => r.Mean));
                    var otherTeam = new Team(new Player(iOtherTeam), otherTeamAverageRating);

                    minQuality = Math.Min(minQuality, mTwoPlayerEloCalculator.CalculateMatchQuality(gameInfo, Teams.Concat(currentTeam, otherTeam)));
                }
            }

            return minQuality;
        }

        private void UpdateDuels<TPlayer>(GameInfo gameInfo,
            IDictionary<TPlayer, IDictionary<TPlayer, double>> duels, TPlayer player1,
            Rating player1Rating, TPlayer player2, Rating player2Rating, 
            PairwiseComparison weakToStrongComparison)
        {
            var duelOutcomes = mTwoPlayerEloCalculator.CalculateNewRatings(gameInfo, 
                Teams.Concat(new Team<TPlayer>(player1, player1Rating), 
                new Team<TPlayer>(player2, player2Rating)), 
                (weakToStrongComparison == PairwiseComparison.Win) ? new int[] { 1, 2 }
                : (weakToStrongComparison == PairwiseComparison.Lose) ? new int[] { 2, 1 }
                : new int[] { 1, 1 });

            UpdateDuelInfo(duels, player1, player1Rating, duelOutcomes[player1], player2);
            UpdateDuelInfo(duels, player2, player2Rating, duelOutcomes[player2], player1);
        }

        private static void UpdateDuelInfo<TPlayer>(IDictionary<TPlayer,
            IDictionary<TPlayer, double>> duels, TPlayer self, Rating selfBeforeRating,
            Rating selfAfterRating, TPlayer opponent)
        {
            if (!duels.TryGetValue(self, out IDictionary<TPlayer, double> selfToOpponentDuelDeltas))
            {
                selfToOpponentDuelDeltas = new Dictionary<TPlayer, double>();
                duels[self] = selfToOpponentDuelDeltas;
            }

            selfToOpponentDuelDeltas[opponent] = selfAfterRating.Mean - selfBeforeRating.Mean;
        }

        private readonly TwoPlayerEloCalculator mTwoPlayerEloCalculator;
    }
}
