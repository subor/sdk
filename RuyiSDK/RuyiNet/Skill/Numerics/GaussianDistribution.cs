using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Represents a Gaussian Distribution using Mean and Standard Deviation.
    /// </summary>
    public class GaussianDistribution
    {
        /// <summary>
        /// Construct a GD using the mean and standard deviation.
        /// </summary>
        /// <param name="mean">The mean of the distribution.</param>
        /// <param name="standardDeviation">The standard deviation of the distribution.</param>
        public GaussianDistribution(double mean, double standardDeviation)
        {
            Mean = mean;
            StandardDeviation = standardDeviation;
            Variance = Square(StandardDeviation);
            Precision = 1.0 / Variance;
            PrecisionMean = Precision * Mean;
            NormalizationConstant = 1.0 / (Sqrt2Pi * StandardDeviation);
        }

        /// <summary>
        /// The mean of the distribution.
        /// </summary>
        public double Mean { get; private set; }

        /// <summary>
        /// The standard deviation of the distribution.
        /// </summary>
        public double StandardDeviation { get; private set; }

        /// <summary>
        /// The precision of the distribution (1 / (SD^2)).
        /// </summary>
        public double Precision { get; private set; }

        /// <summary>
        /// The precision-mean of the distribution (P x M).
        /// </summary>
        public double PrecisionMean { get; private set; }

        private double Variance { get; set; }

        /// <summary>
        /// The normalization constant of the distribution.
        /// </summary>
        public double NormalizationConstant { get; private set; }

        /// <summary>
        /// Create a clone of this distribution.
        /// </summary>
        /// <returns>A copy of the distribution in a new object.</returns>
        public GaussianDistribution Clone()
        {
            var result = new GaussianDistribution
            {
                Mean = Mean,
                StandardDeviation = StandardDeviation,
                Variance = Variance,
                Precision = Precision,
                PrecisionMean = PrecisionMean,
                NormalizationConstant = NormalizationConstant
            };

            return result;
        }

        /// <summary>
        /// Create a GD from the precision mean.
        /// </summary>
        /// <param name="precisionMean">The precision mean of the distribution.</param>
        /// <param name="precision">The precision of the distribution.</param>
        /// <returns></returns>
        public static GaussianDistribution FromPrecisionMean(double precisionMean, double precision)
        {
            var gaussianDistribution = new GaussianDistribution
            {
                Precision = precision,
                PrecisionMean = precisionMean,
                Variance = 1.0 / precision
            };

            gaussianDistribution.StandardDeviation = Math.Sqrt(gaussianDistribution.Variance);
            gaussianDistribution.Mean = precisionMean / precision;
            gaussianDistribution.NormalizationConstant = 1.0 / (Sqrt2Pi * gaussianDistribution.StandardDeviation);
            return gaussianDistribution;
        }

        /// <summary>
        /// Returns the result of multiplying two gaussian distributions.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>The resulting gaussian distribution.</returns>
        public static GaussianDistribution operator *(GaussianDistribution left, GaussianDistribution right)
        {
            return FromPrecisionMean(left.PrecisionMean + right.PrecisionMean, left.Precision + right.Precision);
        }

        /// <summary>
        /// Get the absolute difference between two distributions.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns></returns>
        public static double AbsoluteDifference(GaussianDistribution left, GaussianDistribution right)
        {
            return Math.Max(Math.Abs(left.PrecisionMean - right.PrecisionMean), Math.Sqrt(Math.Abs(left.Precision - right.Precision)));
        }

        /// <summary>
        /// Get the absolute difference between two distributions.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns></returns>
        public static double operator -(GaussianDistribution left, GaussianDistribution right)
        {
            return AbsoluteDifference(left, right);
        }

        /// <summary>
        /// Returns the result of a log product operation.
        /// </summary>
        /// <param name="left">The lvalue.</param>
        /// <param name="right">The rvalue.</param>
        /// <returns>The result of the log product.</returns>
        public static double LogProductNormalization(GaussianDistribution left, GaussianDistribution right)
        {
            if ((left.Precision == 0) ||
                (right.Precision == 0))
            {
                return 0;
            }

            var varianceSum = left.Variance + right.Variance;
            var meanDifference = left.Mean - right.Mean;

            return -LogSqrt2Pi - (Math.Log(varianceSum) * 0.5) - (Square(meanDifference) / (2.0 * varianceSum));
        }

        /// <summary>
        /// Returns the result of dividing two gaussian distributions.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <returns>The resulting gaussian distribution.</returns>
        public static GaussianDistribution operator /(GaussianDistribution numerator, GaussianDistribution denominator)
        {
            return FromPrecisionMean(numerator.PrecisionMean - denominator.PrecisionMean, numerator.Precision - denominator.Precision);
        }

        /// <summary>
        /// Returns the result of a log ratio normalization.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <returns>The resulting scalar.</returns>
        public static double LogRatioNormalization(GaussianDistribution numerator, GaussianDistribution denominator)
        {
            if ((numerator.Precision == 0) ||
                (denominator.Precision == 0))
            {
                return 0;
            }

            var varianceDifference = denominator.Variance - numerator.Variance;
            var meanDifference = numerator.Mean - denominator.Mean;

            return Math.Log(denominator.Variance) + LogSqrt2Pi - Math.Log(varianceDifference) * 0.5 + Square(meanDifference) / (2 * varianceDifference);
        }

        /// <summary>
        /// Returns the value at 'x'.
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <returns>The value of y at x.</returns>
        public static double At(double x)
        {
            return At(x, 0, 1);
        }

        /// <summary>
        /// Returns the value at 'x'.
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <param name="mean">The mean of the distribution.</param>
        /// <param name="standardDeviation">The standard deviation of the distribution.</param>
        /// <returns>The value of y at x.</returns>
        public static double At(double x, double mean, double standardDeviation)
        {
            var multiplier = 1.0 / (standardDeviation * Sqrt2Pi);
            var expPart = Math.Exp((-1.0 * Math.Pow(x - mean, 2.0)) / (2 * Square(standardDeviation)));
            var result = multiplier * expPart;
            return result;
        }

        /// <summary>
        /// Returns the area under the curve up to 'x'
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <param name="mean">The mean of the distribution.</param>
        /// <param name="standardDeviation">The standard deviation of the distribution.</param>
        /// <returns>The area under the curve up to x.</returns>
        public static double CumulativeTo(double x, double mean, double standardDeviation)
        {
            var result = ErrorFunctionCumulativeTo(-HalfSqrt2 * x);
            return 0.5 * result;
        }

        /// <summary>
        /// Returns the area under the curve up to 'x'
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <returns>The area under the curve up to x.</returns>
        public static double CumulativeTo(double x)
        {
            return CumulativeTo(x, 0, 1);
        }

        /// <summary>
        /// Returns the area under the curve after 'x'
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <param name="mean">The mean of the distribution.</param>
        /// <param name="standardDeviation">The standard deviation of the distribution.</param>
        /// <returns>The area under the curve after x.</returns>
        public static double InverseCumulativeTo(double x, double mean, double standardDeviation)
        {
            return mean - Sqrt2 * standardDeviation * InverseErrorFunctionCumulativeTo(2 * x);
        }

        /// <summary>
        /// Returns the area under the curve after 'x'
        /// </summary>
        /// <param name="x">The input 'x' parameter.</param>
        /// <returns>The area under the curve after x.</returns>
        public static double InverseCumulativeTo(double x)
        {
            return InverseCumulativeTo(x, 0, 1);
        }

        /// <summary>
        /// Convert the gaussian distribution to a string.
        /// </summary>
        /// <returns>A string showing the mean and standard deviation of the distribution.</returns>
        public override string ToString()
        {
            return String.Format("μ={0:0.0000}, σ={1:0.0000}", Mean, StandardDeviation);
        }

        private GaussianDistribution()
        {
        }

        private static double ErrorFunctionCumulativeTo(double x)
        {
            double z = Math.Abs(x);

            double t = 2.0 / (2.0 + z);
            double ty = 4 * t - 2;

            double[] coefficients =
            {
                -1.3026537197817094, 6.4196979235649026e-1, 1.9476473204185836e-2,
                -9.561514786808631e-3, -9.46595344482036e-4, 3.66839497852761e-4,
                4.2523324806907e-5, -2.0278578112534e-5, -1.624290004647e-6, 1.303655835580e-6,
                1.5626441722e-8, -8.5238095915e-8, 6.529054439e-9, 5.059343495e-9,
                -9.91364156e-10, -2.27365122e-10, 9.6467911e-11, 2.394038e-12, -6.886027e-12,
                8.94487e-13, 3.13092e-13, -1.12708e-13, 3.81e-16, 7.106e-15, -1.523e-15,
                -9.4e-17, 1.21e-16, -2.8e-17
            };

            int ncof = coefficients.Length;
            double d = 0.0;
            double dd = 0.0;


            for (int j = ncof - 1; j > 0; --j)
            {
                double tmp = d;
                d = ty * d - dd + coefficients[j];
                dd = tmp;
            }

            double ans = t * Math.Exp(-z * z + 0.5 * (coefficients[0] + ty * d) - dd);
            return x >= 0.0 ? ans : (2.0 - ans);
        }

        private static double InverseErrorFunctionCumulativeTo(double p)
        {
            if (p >= 2.0)
            {
                return -100;
            }

            if (p <= 0.0)
            {
                return 100;
            }

            double pp = (p < 1.0) ? p : 2 - p;
            double t = Math.Sqrt(-2 * Math.Log(pp * 0.5));
            double x = -0.70711 * ((2.30753 + t * 0.27061) / (1.0 + t * (0.99229 + t * 0.04481)) - t);

            for (int j = 0; j < 2; ++j)
            {
                double err = ErrorFunctionCumulativeTo(x) - pp;
                x += err / (1.12837916709551257 * Math.Exp(-(x * x)) - x * err);
            }

            return p < 1.0 ? x : -x;
        }

        private static double Square(double x) { return x * x; }

        private static readonly double Sqrt2 = Math.Sqrt(2);
        private static readonly double HalfSqrt2 = Math.Sqrt(2) * 0.5;
        private static readonly double Sqrt2Pi = Math.Sqrt(2 * Math.PI);
        private static readonly double LogSqrt2Pi = Math.Log(Sqrt2Pi);
    }
}
