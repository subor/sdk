using NUnit.Framework;

namespace Ruyi.SDK.Cloud.Tests.Trueskill
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
