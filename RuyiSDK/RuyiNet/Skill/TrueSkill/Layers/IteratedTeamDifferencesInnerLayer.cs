using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    internal class IteratedTeamDifferencesInnerLayer<TPlayer> :
        TrueSkillFactorGraphLayer<TPlayer, Variable<GaussianDistribution>,
            GaussianWeightedSumFactor, Variable<GaussianDistribution>>
    {

        public IteratedTeamDifferencesInnerLayer(TrueSkillFactorGraph<TPlayer> parentGraph,
            TeamPerformancesToTeamPerformanceDifferencesLayer<TPlayer> teamPerformancesToTeamPerformanceDifferences,
            TeamDifferencesComparisonLayer<TPlayer> teamDifferencesComparisonLayer)
            : base(parentGraph)
        {
            mTeamPerformancesToTeamPerformanceDifferencesLayer = teamPerformancesToTeamPerformanceDifferences;
            mTeamDifferencesComparisonLayer = teamDifferencesComparisonLayer;
        }

        public override void BuildLayer()
        {
            mTeamPerformancesToTeamPerformanceDifferencesLayer.SetRawInputVariablesGroups(InputVariablesGroups);
            mTeamPerformancesToTeamPerformanceDifferencesLayer.BuildLayer();

            mTeamDifferencesComparisonLayer.SetRawInputVariablesGroups(
                mTeamPerformancesToTeamPerformanceDifferencesLayer.GetRawOutputVariablesGroups());
            mTeamDifferencesComparisonLayer.BuildLayer();
        }

        public override Schedule<GaussianDistribution> CreatePriorSchedule()
        {
            Schedule<GaussianDistribution> loop = null;

            switch (InputVariablesGroups.Count)
            {
                case 0:
                case 1:
                    throw new InvalidOperationException();

                case 2:
                    loop = CreateTwoTeamInnerPriorLoopSchedule();
                    break;

                default:
                    loop = CreateMultipleTeamInnerPriorLoopSchedule();
                    break;
            }

            var totalTeamDifferences = mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors.Count;
            var totalTeams = totalTeamDifferences + 1;

            var innerSchedule = new ScheduleSequence<GaussianDistribution>("inner schedule", new[]
            {
                loop,
                new ScheduleStep<GaussianDistribution>(
                    "teamPerformanceToPerformanceDifferenceFactors[0] @ 1",
                    mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[0], 1),
                new ScheduleStep<GaussianDistribution>(
                    String.Format("teamPerformanceToPerformanceDifferenceFactors[teamTeamDifferences = {0} - 1] @ 2", totalTeamDifferences),
                    mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[totalTeamDifferences - 1], 2)
            });

            return innerSchedule;
        }

        public override IEnumerable<Factor<GaussianDistribution>> UntypedFactors
        {
            get
            {
                return mTeamPerformancesToTeamPerformanceDifferencesLayer.UntypedFactors.Concat(
                    mTeamDifferencesComparisonLayer.UntypedFactors);
            }
        }

        private Schedule<GaussianDistribution> CreateTwoTeamInnerPriorLoopSchedule()
        {
            return ScheduleSequence(new[]
            {
                new ScheduleStep<GaussianDistribution>(
                    "send team perf to perf differences",
                    mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[0], 0),
                new ScheduleStep<GaussianDistribution>(
                    "send to greater than or within factor",
                    mTeamDifferencesComparisonLayer.LocalFactors[0], 0)
            },
            "loop of just two teams inner sequence");
        }

        private Schedule<GaussianDistribution> CreateMultipleTeamInnerPriorLoopSchedule()
        {
            var totalTeamDifferences = mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors.Count;

            var forwardScheduleList = new List<Schedule<GaussianDistribution>>();

            for (var i = 0; i < totalTeamDifferences - 1; ++i)
            {
                var currentForwardSchedulePiece = ScheduleSequence(new Schedule<GaussianDistribution>[]
                    {
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("team perf to perf diff {0}", i),
                            mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[i], 0),
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("greater than or within result factor {0}", i),
                            mTeamDifferencesComparisonLayer.LocalFactors[i], 0),
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("team perf to perf diff factors {0}, 2", i),
                            mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[i], 2),
                    }, "current forward schedule piece {0}", 1);

                forwardScheduleList.Add(currentForwardSchedulePiece);                        
            }

            var forwardSchedule = new ScheduleSequence<GaussianDistribution>(
                "forward schedule", forwardScheduleList);

            var backwardScheduleList = new List<Schedule<GaussianDistribution>>();

            for (var i = 0; i < totalTeamDifferences - 1; ++i)
            {
                var currentBackwardSchedulePiece = new ScheduleSequence<GaussianDistribution>(
                    "current backward schedule piece",
                    new Schedule<GaussianDistribution>[]
                    {
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("teamPerformanceToPerformanceDifferenceFactors[totalTeamDifferences - 1 - {0}] @ 0", i),
                            mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[totalTeamDifferences - 1 - i], 0),
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("greaterThanOrWithinResultFactors[totalTeamDifferences - 1 - {0}] @ 0", i),
                            mTeamDifferencesComparisonLayer.LocalFactors[totalTeamDifferences - 1 - i], 0),
                        new ScheduleStep<GaussianDistribution>(
                            String.Format("teamPerformanceToPerformanceDifferenceFactors[totalTeamDifferences - 1 - {0}] @ 1", i),
                            mTeamPerformancesToTeamPerformanceDifferencesLayer.LocalFactors[totalTeamDifferences - 1 - i], 1),
                    });

                backwardScheduleList.Add(currentBackwardSchedulePiece);
            }

            var backwardSchedule = new ScheduleSequence<GaussianDistribution>(
                "backward schedule", backwardScheduleList);

            var forwardBackwardScheduleToLoop = new ScheduleSequence<GaussianDistribution>(
                "forward Backward Schedule To Loop",
                new Schedule<GaussianDistribution>[]
                {
                    forwardSchedule, backwardSchedule

                });

            const double initialMaxDelta = 0.0001;

            var loop = new ScheduleLoop<GaussianDistribution>(
                String.Format("loop with max delta of {0}", initialMaxDelta),
                forwardBackwardScheduleToLoop,
                initialMaxDelta);

            return loop;
        }

        private readonly TeamDifferencesComparisonLayer<TPlayer> mTeamDifferencesComparisonLayer;
        private readonly TeamPerformancesToTeamPerformanceDifferencesLayer<TPlayer> mTeamPerformancesToTeamPerformanceDifferencesLayer;
    }
}
