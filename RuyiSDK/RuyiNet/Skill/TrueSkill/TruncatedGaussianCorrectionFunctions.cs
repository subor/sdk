using System;

namespace Ruyi.SDK.Cloud
{
    internal static class TruncatedGaussianCorrectionFunctions
    {
        public static double VExceedsMargin(double teamPerformanceDifference, double drawMargin, double c)
        {
            return VExceedsMargin(teamPerformanceDifference / c, drawMargin / c);
        }

        public static double VExceedsMargin(double teamPerformanceDifference, double drawMargin)
        {
            double denominator = GaussianDistribution.CumulativeTo(teamPerformanceDifference - drawMargin);
            if (denominator < 2.222758749e-162)
            {
                return -teamPerformanceDifference + drawMargin;
            }

            return GaussianDistribution.At(teamPerformanceDifference - drawMargin) / denominator;
        }

        public static double WExceedsMargin(double teamPerformanceDifference, double drawMargin, double c)
        {
            return WExceedsMargin(teamPerformanceDifference / c, drawMargin / c);
        }

        public static double WExceedsMargin(double teamPerformanceDifference, double drawMargin)
        {
            double denominator = GaussianDistribution.CumulativeTo(teamPerformanceDifference - drawMargin);
            if (denominator < 2.222758749e-162)
            {
                if (teamPerformanceDifference < 0.0)
                {
                    return 1.0;
                }

                return 0.0;
            }

            double vWin = VExceedsMargin(teamPerformanceDifference, drawMargin);
            return vWin * (vWin + teamPerformanceDifference - drawMargin);
        }

        public static double VWithinMargin(double teamPerformanceDifference, double drawMargin, double c)
        {
            return VWithinMargin(teamPerformanceDifference / c, drawMargin / c);
        }

        public static double VWithinMargin(double teamPerformanceDifference, double drawMargin)
        {
            double teamPerformanceDifferenceAbsoluteValue = Math.Abs(teamPerformanceDifference);
            double denominator =
                GaussianDistribution.CumulativeTo(drawMargin - teamPerformanceDifferenceAbsoluteValue) -
                GaussianDistribution.CumulativeTo(-drawMargin - teamPerformanceDifferenceAbsoluteValue);

            if (denominator < 2.222758749e-162)
            {
                if (teamPerformanceDifference < 0.0)
                {
                    return -teamPerformanceDifference - drawMargin;
                }

                return -teamPerformanceDifference + drawMargin;
            }

            double numerator = GaussianDistribution.At(-drawMargin - teamPerformanceDifferenceAbsoluteValue) -
                               GaussianDistribution.At(drawMargin - teamPerformanceDifferenceAbsoluteValue);

            if (teamPerformanceDifference < 0.0)
            {
                return -numerator / denominator;
            }

            return numerator / denominator;
        }

        public static double WWithinMargin(double teamPerformanceDifference, double drawMargin, double c)
        {
            return WWithinMargin(teamPerformanceDifference / c, drawMargin / c);
        }

        public static double WWithinMargin(double teamPerformanceDifference, double drawMargin)
        {
            double teamPerformanceDifferenceAbsoluteValue = Math.Abs(teamPerformanceDifference);
            double denominator = GaussianDistribution.CumulativeTo(drawMargin - teamPerformanceDifferenceAbsoluteValue) -
                                 GaussianDistribution.CumulativeTo(-drawMargin - teamPerformanceDifferenceAbsoluteValue);

            if (denominator < 2.222758749e-162)
            {
                return 1.0;
            }

            double vt = VWithinMargin(teamPerformanceDifferenceAbsoluteValue, drawMargin);

            return vt * vt + ((drawMargin - teamPerformanceDifferenceAbsoluteValue) *
                       GaussianDistribution.At(drawMargin - teamPerformanceDifferenceAbsoluteValue) -
                                               (-drawMargin - teamPerformanceDifferenceAbsoluteValue) *
                                               GaussianDistribution.At(-drawMargin - teamPerformanceDifferenceAbsoluteValue)) / denominator;
        }
    }
}