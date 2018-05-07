namespace Ruyi.SDK.Cloud
{
    internal class TeamPerformancesToTeamPerformanceDifferencesLayer<TPlayer>
        : TrueSkillFactorGraphLayer<TPlayer, Variable<GaussianDistribution>, GaussianWeightedSumFactor, Variable<GaussianDistribution>>
    {
        public TeamPerformancesToTeamPerformanceDifferencesLayer(TrueSkillFactorGraph<TPlayer> parentGraph)
            : base(parentGraph)
        {
        }

        public override void BuildLayer()
        {
            for (var i = 0; i < InputVariablesGroups.Count - 1; ++i)
            {
                var strongerTeam = InputVariablesGroups[i][0];
                var weakerTeam = InputVariablesGroups[i + 1][0];

                var currentDifference = CreateOutputVariable();
                AddLayerFactor(CreateTeamPerformanceToDifferenceFactor(strongerTeam, weakerTeam, currentDifference));

                OutputVariablesGroup.Add(new[] { currentDifference });
            }
        }

        private GaussianWeightedSumFactor CreateTeamPerformanceToDifferenceFactor(
            Variable<GaussianDistribution> strongerTeam, Variable<GaussianDistribution> weakerTeam,
            Variable<GaussianDistribution> output)
        {
            return new GaussianWeightedSumFactor(output, new[] { strongerTeam, weakerTeam }, new[] { 1.0, -1.0 });
        }

        private Variable<GaussianDistribution> CreateOutputVariable()
        {
            return ParentFactorGraph.VariableFactory.CreateBasicVariable("Team performance difference");
        }
    }
}
