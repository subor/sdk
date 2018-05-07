namespace Ruyi.SDK.Cloud
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
