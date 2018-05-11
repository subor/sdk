using NUnit.Framework;

namespace Ruyi.SDK.Online.Tests.Trueskill
{
    [TestFixture]
    public class TwoTeamTrueSkillCalculatorTest
    {
        [Test]
        public void TwoTeamTrueSkillCalculatorTests()
        {
            var calculator = new TwoTeamTrueSkillCalculator();

            TrueSkillCalculatorTests.TestAllTwoPlayerScenarios(calculator);
            TrueSkillCalculatorTests.TestAllTwoTeamScenarios(calculator);
        }
    }
}
