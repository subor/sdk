using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    public class TrueSkillFactorGraph<TPlayer> 
        : FactorGraph<TrueSkillFactorGraph<TPlayer>, GaussianDistribution, Variable<GaussianDistribution>>
    {
        public TrueSkillFactorGraph(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams, int[] teamRanks)
        {
            mPriorLayer = new PlayerPriorValuesToSkillsLayer<TPlayer>(this, teams);
            GameInfo = gameInfo;
            VariableFactory = new VariableFactory<GaussianDistribution>(() => GaussianDistribution.FromPrecisionMean(0, 0));
            mLayers = new List<FactorGraphLayerBase<GaussianDistribution>>
            {
                mPriorLayer,
                new PlayerSkillsToPerformancesLayer<TPlayer>(this),
                new PlayerPerformancesToTeamPerformancesLayer<TPlayer>(this),
                new IteratedTeamDifferencesInnerLayer<TPlayer>(
                    this,
                    new TeamPerformancesToTeamPerformanceDifferencesLayer<TPlayer>(this),
                    new TeamDifferencesComparisonLayer<TPlayer>(this, teamRanks))
            };
        }

        public void BuildGraph()
        {
            object lastOutput = null;
            foreach (var currentLayer in mLayers)
            {
                if (lastOutput != null)
                {
                    currentLayer.SetRawInputVariablesGroups(lastOutput);
                }

                currentLayer.BuildLayer();

                lastOutput = currentLayer.GetRawOutputVariablesGroups();
            }
        }

        public void RunSchedule()
        {
            Schedule<GaussianDistribution> fullSchedule = CreateFullSchedule();
            var fullScheduleDelta = fullSchedule.Visit();
        }

        public double GetProbabilityOfRanking()
        {
            var factorList = new FactorList<GaussianDistribution>();

            foreach (var currentLayer in mLayers)
            {
                foreach (var currentFactor in currentLayer.UntypedFactors)
                {
                    factorList.AddFactor(currentFactor);
                }
            }

            var logZ = factorList.LogNormalization;
            return Math.Exp(logZ);
        }

        public IDictionary<TPlayer, Rating> GetUpdatedRatings()
        {
            var result = new Dictionary<TPlayer, Rating>();
            foreach (var currentTeam in mPriorLayer.OutputVariablesGroup)
            {
                foreach (var currentPlayer in currentTeam)
                {
                    result[currentPlayer.Key] = new Rating(currentPlayer.Value.Mean, currentPlayer.Value.StandardDeviation);
                }
            }

            return result;
        }

        public GameInfo GameInfo { get; private set; }

        private Schedule<GaussianDistribution> CreateFullSchedule()
        {
            var fullSchedule = new List<Schedule<GaussianDistribution>>();

            foreach (var currentLayer in mLayers)
            {
                Schedule<GaussianDistribution> currentPriorSchedule = currentLayer.CreatePriorSchedule();
                if (currentPriorSchedule != null)
                {
                    fullSchedule.Add(currentPriorSchedule);
                }
            }

            IEnumerable<FactorGraphLayerBase<GaussianDistribution>> allLayers = mLayers;

            foreach (var currentLayer in allLayers.Reverse())
            {
                Schedule<GaussianDistribution> currentPosteriorSchedule = currentLayer.CreatePosteriorSchedule();
                if (currentPosteriorSchedule != null)
                {
                    fullSchedule.Add(currentPosteriorSchedule);
                }
            }

            return new ScheduleSequence<GaussianDistribution>("Full schedule", fullSchedule);
        }

        private readonly List<FactorGraphLayerBase<GaussianDistribution>> mLayers;
        private readonly PlayerPriorValuesToSkillsLayer<TPlayer> mPriorLayer;
    }
}
