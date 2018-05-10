using System;

namespace Ruyi.SDK.Online
{
    public static class DrawMargin
    {
        public static double GetDrawMarginFromDrawProbability(double drawProbability, double beta)
        {
            return GaussianDistribution.InverseCumulativeTo(0.5 * (drawProbability + 1), 0, 1) * Sqrt2 * beta;
        }

        private static readonly double Sqrt2 = Math.Sqrt(2);
    }
}
