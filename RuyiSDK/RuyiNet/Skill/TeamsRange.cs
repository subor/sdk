namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A class used to specify the valid value range for team IDs.
    /// </summary>
    public class TeamsRange : Range<TeamsRange>
    {
        /// <summary>
        /// Default construction - team IDs can be any integer value.
        /// </summary>
        public TeamsRange()
            : base(int.MinValue, int.MaxValue)
        {
        }

        /// <summary>
        /// Create a team range with minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The newly created Team Range.</returns>
        protected override TeamsRange Create(int min, int max)
        {
            return new TeamsRange(min, max);
        }

        private TeamsRange(int min, int max)
            : base(min, max)
        {
        }
    }
}
