namespace Ruyi.SDK.Online
{
    internal class TeamDifferencesComparisonLayer<TPlayer>
        : TrueSkillFactorGraphLayer<TPlayer, Variable<GaussianDistribution>, 
            GaussianFactor, DefaultVariable<GaussianDistribution>>
    {
        public TeamDifferencesComparisonLayer(TrueSkillFactorGraph<TPlayer> parentGraph, int[] teamRanks)
            : base(parentGraph)
        {
            mTeamRanks = teamRanks;
            var gameInfo = ParentFactorGraph.GameInfo;
            mEpsilon = DrawMargin.GetDrawMarginFromDrawProbability(gameInfo.DrawProbability, gameInfo.Beta);
        }

        public override void BuildLayer()
        {
            for (var i = 0; i < InputVariablesGroups.Count; ++i)
            {
                var isDraw = (mTeamRanks[i] == mTeamRanks[i + 1]);
                var teamDifference = InputVariablesGroups[i][0];
                var factor = isDraw ?
                    (GaussianFactor)new GaussianWithinFactor(mEpsilon, teamDifference) :
                    new GaussianGreaterThanFactor(mEpsilon, teamDifference);

                AddLayerFactor(factor);
            }
        }

        private readonly double mEpsilon;
        private readonly int[] mTeamRanks;
    }
}
