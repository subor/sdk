using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    internal class PlayerPerformancesToTeamPerformancesLayer<TPlayer>
        : TrueSkillFactorGraphLayer<TPlayer, KeyedVariable<TPlayer, GaussianDistribution>, 
            GaussianWeightedSumFactor, Variable<GaussianDistribution>>
    {
        public PlayerPerformancesToTeamPerformancesLayer(TrueSkillFactorGraph<TPlayer> parentGraph)
            : base(parentGraph)
        {
        }

        public override void BuildLayer()
        {
            foreach (var currentTeam in InputVariablesGroups)
            {
                var teamPerformance = CreateOutputVariable(currentTeam);
                AddLayerFactor(CreatePlayerToTeamSumFactor(currentTeam, teamPerformance));
                OutputVariablesGroup.Add(new[] { teamPerformance });
            }
        }

        public override Schedule<GaussianDistribution> CreatePosteriorSchedule()
        {
            return ScheduleSequence(
                from currentFactor in LocalFactors
                from currentIteration in
                    Enumerable.Range(1, currentFactor.NumberOfMessages - 1)
                select new ScheduleStep<GaussianDistribution>(
                    "team sum perf @" + currentIteration,
                    currentFactor,
                    currentIteration),
                "all of the team's sum iterations");
        }

        protected GaussianWeightedSumFactor CreatePlayerToTeamSumFactor(
            IList<KeyedVariable<TPlayer, GaussianDistribution>> teamMembers,
            Variable<GaussianDistribution> sumVariable)
        {
            return new GaussianWeightedSumFactor(sumVariable, teamMembers.ToArray(),
                teamMembers.Select(v => PartialPlay.GetPartialPlayPercentage(v.Key)).ToArray());
        }

        private Variable<GaussianDistribution> CreateOutputVariable(
            IList<KeyedVariable<TPlayer, GaussianDistribution>> team)
        {
            string teamMemberNames = String.Join(", ", team.Select(teamMember => teamMember.Key.ToString()).ToArray());
            return ParentFactorGraph.VariableFactory.CreateBasicVariable("Team[{0}]'s performance", teamMemberNames);
        }
    }
}
