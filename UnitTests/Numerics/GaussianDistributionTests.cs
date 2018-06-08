using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online.Tests.Numerics
{
    [TestFixture]
    class GaussianDistributionTests
    {
        private const double ErrorTolerance = 0.000001;

        [Test]
        public void CumulativeToTests()
        {
            Assert.AreEqual(0.691462, GaussianDistribution.CumulativeTo(0.5), ErrorTolerance);
        }

        [Test]
        public void AtTests()
        {
            Assert.AreEqual(0.352065, GaussianDistribution.At(0.5), ErrorTolerance);
        }

        [Test]
        public void MultiplicationTests()
        {
            var standardNormal = new GaussianDistribution(0, 1);
            var shiftedGaussian = new GaussianDistribution(2, 3);

            var product = standardNormal * shiftedGaussian;

            Assert.AreEqual(0.2, product.Mean, ErrorTolerance);
            Assert.AreEqual(3.0 / Math.Sqrt(10), product.StandardDeviation, ErrorTolerance);

            var m4s5 = new GaussianDistribution(4, 5);
            var m6s7 = new GaussianDistribution(6, 7);

            var product2 = m4s5 * m6s7;
            Func<double, double> square = x => x * x;

            var expectedMean = (4 * square(7) + 6 * square(5)) / (square(5) + square(7));
            Assert.AreEqual(expectedMean, product2.Mean, ErrorTolerance);

            var expectedSigma = Math.Sqrt(((square(5) * square(7)) / (square(5) + square(7))));
            Assert.AreEqual(expectedSigma, product2.StandardDeviation, ErrorTolerance);
        }

        [Test]
        public void DivisionTests()
        {
            var product = new GaussianDistribution(0.2, 3.0 / Math.Sqrt(10));
            var standardNormal = new GaussianDistribution(0, 1);

            var productDividedByStandardNormal = product / standardNormal;
            Assert.AreEqual(2.0, productDividedByStandardNormal.Mean, ErrorTolerance);
            Assert.AreEqual(3.0, productDividedByStandardNormal.StandardDeviation, ErrorTolerance);

            Func<double, double> square = x => x * x;
            var product2 = new GaussianDistribution((4 * square(7) + 6 * square(5)) / (square(5) + square(7)), Math.Sqrt(((square(5) * square(7)) / (square(5) + square(7)))));
            var m4s5 = new GaussianDistribution(4, 5);
            var product2DividedByM4S5 = product2 / m4s5;
            Assert.AreEqual(6.0, product2DividedByM4S5.Mean, ErrorTolerance);
            Assert.AreEqual(7.0, product2DividedByM4S5.StandardDeviation, ErrorTolerance);
        }

        [Test]
        public void LogProductNormalizationTests()
        {
            var standardNormal = new GaussianDistribution(0, 1);
            var lpn = GaussianDistribution.LogProductNormalization(standardNormal, standardNormal);
            Assert.AreEqual(-1.2655121234846454, lpn, ErrorTolerance);

            var m1s2 = new GaussianDistribution(1, 2);
            var m3s4 = new GaussianDistribution(3, 4);
            var lpn2 = GaussianDistribution.LogProductNormalization(m1s2, m3s4);
            Assert.AreEqual(-2.5168046699816684, lpn2, ErrorTolerance);
        }

        [Test]
        public void LogRatioNormalizationTests()
        {        
            var m1s2 = new GaussianDistribution(1, 2);
            var m3s4 = new GaussianDistribution(3, 4);
            var lrn = GaussianDistribution.LogRatioNormalization(m1s2, m3s4);
            Assert.AreEqual(2.6157405972171204, lrn, ErrorTolerance);
        }

        [Test]
        public void AbsoluteDifferenceTests()
        {     
            var standardNormal = new GaussianDistribution(0, 1);
            var absDiff = GaussianDistribution.AbsoluteDifference(standardNormal, standardNormal);
            Assert.AreEqual(0.0, absDiff, ErrorTolerance);

            var m1s2 = new GaussianDistribution(1, 2);
            var m3s4 = new GaussianDistribution(3, 4);
            var absDiff2 = GaussianDistribution.AbsoluteDifference(m1s2, m3s4);
            Assert.AreEqual(0.4330127018922193, absDiff2, ErrorTolerance);
        }
    }
}
