using System;

namespace Ruyi
{
    /// <summary>
    /// Represents a player's rating.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Construct a rating.
        /// </summary>
        /// <param name="mean">The mean of the bell curve.</param>
        /// <param name="standardDeviation">The standard deviation of the bell curve.</param>
        public Rating(double mean, double standardDeviation)
            : this(mean, standardDeviation, ConservativeStandardDeviationMultiplier)
        {
        }

        /// <summary>
        /// Construct a rating.
        /// </summary>
        /// <param name="mean">The mean of the bell curve.</param>
        /// <param name="standardDeviation">The standard deviation of the bell curve.</param>
        /// <param name="conservativeStandardDeviationMultiplier">The multiplier used to create a conservative rating.</param>
        public Rating(double mean, double standardDeviation, 
            double conservativeStandardDeviationMultiplier)
        {
            mMean = mean;
            mStandardDeviation = standardDeviation;
            mConservativeStandardDeviationMultiplier = conservativeStandardDeviationMultiplier;
        }

        /// <summary>
        /// The mean of the bell curve.
        /// </summary>
        public double Mean { get { return mMean; } }

        /// <summary>
        /// The standard deviation of the bell curve.
        /// </summary>
        public double StandardDeviation { get { return mStandardDeviation; } }

        /// <summary>
        /// Calculate the conservative rating.
        /// </summary>
        public double ConservativeRating
        {
            get
            {
                return mMean - mConservativeStandardDeviationMultiplier * mStandardDeviation;
            }
        }

        /// <summary>
        /// Get a partial update of a rating.
        /// </summary>
        /// <param name="prior">The rating before adjustment.</param>
        /// <param name="fullPosterior">The rating after adjustment.</param>
        /// <param name="updatePercentage">The percentage of the update to apply.</param>
        /// <returns>The resulting rating after a partial update.</returns>
        public static Rating GetPartialUpdate(Rating prior, Rating fullPosterior,
            double updatePercentage)
        {
            var priorGaussian = new GaussianDistribution(prior.Mean, prior.StandardDeviation);
            var posteriorGaussian = new GaussianDistribution(fullPosterior.Mean, fullPosterior.StandardDeviation);

            var precisionDifference = posteriorGaussian.Precision - priorGaussian.Precision;
            var partialPrecisionDifference = updatePercentage * precisionDifference;

            var precisionMeanDifference = posteriorGaussian.PrecisionMean - priorGaussian.PrecisionMean;
            double partialPrecisionMeanDifference = updatePercentage * precisionMeanDifference;

            GaussianDistribution partialPosteriorGaussian = GaussianDistribution.FromPrecisionMean(
                priorGaussian.PrecisionMean + partialPrecisionMeanDifference,
                priorGaussian.Precision + partialPrecisionDifference);

            return new Rating(partialPosteriorGaussian.Mean, partialPosteriorGaussian.StandardDeviation,
                prior.mConservativeStandardDeviationMultiplier);
        }

        /// <summary>
        /// Convert the rating to a string.
        /// </summary>
        /// <returns>A string representation of the rating.</returns>
        public override string ToString()
        {
            return String.Format("μ={0:0.0000}, σ={1:0.0000}", Mean, StandardDeviation);
        }

        private const int ConservativeStandardDeviationMultiplier = 3;
        private readonly double mConservativeStandardDeviationMultiplier;
        private readonly double mMean;
        private readonly double mStandardDeviation;
    }
}
