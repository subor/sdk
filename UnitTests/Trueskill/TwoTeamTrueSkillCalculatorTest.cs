using NUnit.Framework;
using Ruyi;

namespace UnitTests.Trueskill
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
