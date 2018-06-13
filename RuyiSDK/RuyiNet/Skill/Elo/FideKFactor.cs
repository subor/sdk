namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A k-factor used when calculating ELO ratings using Fide.
    /// </summary>
    public class FideKFactor : KFactor
    {
        /// <summary>
        /// Default construction.
        /// </summary>
        public FideKFactor()
        {
        }

        /// <summary>
        /// Returns the k-factor for the specified rating.
        /// </summary>
        /// <param name="rating">The rating to get the k-factor for.</param>
        /// <returns>15 if the rating is less than 2400, otherwise 10.</returns>
        public override double GetValueForRating(double rating)
        {
            if (rating < 2400)
            {
                return 15;
            }

            return 10;
        }

        /// <summary>
        /// Provisional k-factor for people who have played less than 30 games.
        /// </summary>
        public class Provisional : FideKFactor
        {
            /// <summary>
            /// Default construction.
            /// </summary>
            public Provisional()
            {
            }

            /// <summary>
            /// Returns the provisional k-factor of 25.
            /// </summary>
            /// <param name="rating">The rating to get the k-factor for.</param>
            /// <returns>25</returns>
            public override double GetValueForRating(double rating)
            {
                return 25;
            }
        }
    }
}
