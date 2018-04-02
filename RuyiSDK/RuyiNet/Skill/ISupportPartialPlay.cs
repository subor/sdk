namespace Ruyi
{
    /// <summary>
    /// The interface for players that support partial play.
    /// </summary>
    public interface ISupportPartialPlay
    {
        /// <summary>
        /// The partial play percentage.
        /// </summary>
        double PartialPlayPercentage { get; }
    }
}
