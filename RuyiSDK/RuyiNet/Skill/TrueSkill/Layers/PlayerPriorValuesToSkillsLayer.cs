using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    internal class PlayerPriorValuesToSkillsLayer<TPlayer>
        : TrueSkillFactorGraphLayer<TPlayer, DefaultVariable<GaussianDistribution>, GaussianPriorFactor, KeyedVariable<TPlayer, GaussianDistribution>>
    {
        public PlayerPriorValuesToSkillsLayer(TrueSkillFactorGraph<TPlayer> parentGraph,
            IEnumerable<IDictionary<TPlayer, Rating>> teams)
            : base(parentGraph)
        {
            mTeams = teams;
        }

        public override void BuildLayer()
        {
            foreach (var currentTeam in mTeams)
            {
                var currentTeamSkills = new List<KeyedVariable<TPlayer, GaussianDistribution>>();
                foreach (var currentTeamPlayer in currentTeam)
                {
                    var playerSkill = CreateSkillOutputVariable(currentTeamPlayer.Key);
                    AddLayerFactor(CreatePriorFactor(currentTeamPlayer.Key, currentTeamPlayer.Value, playerSkill));
                    currentTeamSkills.Add(playerSkill);
                }

                OutputVariablesGroup.Add(currentTeamSkills);
            }
        }

        public override Schedule<GaussianDistribution> CreatePriorSchedule()
        {
            return ScheduleSequence(from prior in LocalFactors
                                    select new ScheduleStep<GaussianDistribution>("Prior to Skill Step", prior, 0), "All priors");
        }

        private GaussianPriorFactor CreatePriorFactor(TPlayer player, Rating priorRating, Variable<GaussianDistribution> skillsVariable)
        {
            return new GaussianPriorFactor(priorRating.Mean,
                (priorRating.StandardDeviation * priorRating.StandardDeviation) +
                (ParentFactorGraph.GameInfo.DynamicsFactor * ParentFactorGraph.GameInfo.DynamicsFactor),
                skillsVariable);
        }

        private KeyedVariable<TPlayer, GaussianDistribution> CreateSkillOutputVariable(TPlayer key)
        {
            return ParentFactorGraph.VariableFactory.CreateKeyedVariable(key, "{0}'s skill", key);
        }

        private readonly IEnumerable<IDictionary<TPlayer, Rating>> mTeams;
    }
}
