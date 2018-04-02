using NUnit.Framework;
using Ruyi;

namespace UnitTests.Trueskill
{
    [TestFixture]
    public class TwoPlayerTrueSkillCalculatorTest
    {
        [Test]
        public void TwoPlayerTrueSkillCalculatorTests()
        {
            var calculator = new TwoPlayerTrueSkillCalculator();
            TrueSkillCalculatorTests.TestAllTwoPlayerScenarios(calculator);
        }
    }
}
