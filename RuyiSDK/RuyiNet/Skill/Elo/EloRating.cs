namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// An Elo rating represented by a single number (mean).
    /// </summary>
    public class EloRating : Rating
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="rating">The initial rating to use.</param>
        public EloRating(double rating)
            : base(rating, 0)
        {
        }
    }
}
