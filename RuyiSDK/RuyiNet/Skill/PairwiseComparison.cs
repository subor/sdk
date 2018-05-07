namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// The type of comparison to make when calculating a new rating.
    /// </summary>
    public enum PairwiseComparison
    {
        /// <summary>
        /// This player won the match.
        /// </summary>
        Win = 1,

        /// <summary>
        /// The match ended in a draw.
        /// </summary>
        Draw = 0,

        /// <summary>
        /// This player lost the match.
        /// </summary>
        Lose = -1
    }
}
