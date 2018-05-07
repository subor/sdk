using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    internal class PlayerSkillsToPerformancesLayer<TPlayer> :
        TrueSkillFactorGraphLayer<TPlayer, KeyedVariable<TPlayer, GaussianDistribution>, GaussianLikelihoodFactor, KeyedVariable<TPlayer, GaussianDistribution>>
    {
        public PlayerSkillsToPerformancesLayer(TrueSkillFactorGraph<TPlayer> parentGraph)
            : base(parentGraph)
        {
        }

        public override void BuildLayer()
        {
            foreach (var currentTeam in InputVariablesGroups)
            {
                var currentTeamPlayerPerformances = new List<KeyedVariable<TPlayer, GaussianDistribution>>();

                foreach (var playerSkillVariable in currentTeam)
                {
                    var playerPerformance = CreateOutputVariable(playerSkillVariable.Key);
                    AddLayerFactor(CreateLikelihood(playerSkillVariable, playerPerformance));
                    currentTeamPlayerPerformances.Add(playerPerformance);
                }

                OutputVariablesGroup.Add(currentTeamPlayerPerformances);
            }
        }

        public override Schedule<GaussianDistribution> CreatePriorSchedule()
        {
            return ScheduleSequence(
                from likelihood in LocalFactors
                select new ScheduleStep<GaussianDistribution>("Skill to Perf step", likelihood, 0),
                "All skill to performance sending");
        }

        public override Schedule<GaussianDistribution> CreatePosteriorSchedule()
        {
            return ScheduleSequence(
               from likelihood in LocalFactors
               select new ScheduleStep<GaussianDistribution>("name", likelihood, 1),
               "All skill to performance sending");
        }

        private GaussianLikelihoodFactor CreateLikelihood(KeyedVariable<TPlayer, GaussianDistribution> playerSkill,
            KeyedVariable<TPlayer, GaussianDistribution> playerPerformance)
        {
            return new GaussianLikelihoodFactor(ParentFactorGraph.GameInfo.Beta * ParentFactorGraph.GameInfo.Beta,
                playerPerformance, playerSkill);
        }

        private KeyedVariable<TPlayer, GaussianDistribution> CreateOutputVariable(TPlayer key)
        {
            return ParentFactorGraph.VariableFactory.CreateKeyedVariable(key, "{0}'s performance", key);
        }
    }
}
