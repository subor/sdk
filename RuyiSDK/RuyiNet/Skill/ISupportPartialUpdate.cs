namespace Ruyi.SDK.Online
{
    /// <summary>
    /// An interface for players that support partial updates.
    /// </summary>
    public interface ISupportPartialUpdate
    {
        /// <summary>
        /// The partial update percentage.
        /// </summary>
        double PartialUpdatePercentage { get; }
    }
}
