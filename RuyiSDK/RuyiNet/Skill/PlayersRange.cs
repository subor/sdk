namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Represents a range of players.
    /// </summary>
    public class PlayersRange : Range<PlayersRange>
    {
        /// <summary>
        /// Create the default players range.
        /// </summary>
        public PlayersRange()
            : base(int.MinValue, int.MaxValue)
        {
        }

        /// <summary>
        /// Create a players range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>The newly created range.</returns>
        protected override PlayersRange Create(int min, int max)
        {
            return new PlayersRange(min, max);
        }

        private PlayersRange(int min, int max)
            : base(min, max)
        {
        }
    }
}
