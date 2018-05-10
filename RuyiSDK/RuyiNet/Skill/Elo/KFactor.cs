namespace Ruyi
{
    /// <summary>
    /// Represents the k-factor used when calculating ELO ratings.
    /// </summary>
    public class KFactor
    {
        /// <summary>
        /// Construct a k-factor.
        /// </summary>
        /// <param name="exactKFactor">The value of this k-factor.</param>
        public KFactor(double exactKFactor)
        {
            mValue = exactKFactor;
        }

        /// <summary>
        /// Get the value for a specified rating.
        /// </summary>
        /// <param name="rating">The rating to get the value for.</param>
        /// <returns>The value of the k-factor for the specified rating.</returns>
        public virtual double GetValueForRating(double rating)
        {
            return mValue;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected KFactor()
        {
        }

        private double mValue;
    }
}
