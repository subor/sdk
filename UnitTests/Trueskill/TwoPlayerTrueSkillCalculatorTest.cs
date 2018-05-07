using NUnit.Framework;

namespace Ruyi.SDK.Online.Tests.Trueskill
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
