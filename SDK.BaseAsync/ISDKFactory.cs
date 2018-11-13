
namespace Ruyi.Layer0
{
    /// <summary>
    /// interface of SDK Factory
    /// </summary>
    public interface ISDKFactory
    {
        /// <summary>
        /// Creates pub/sub subscriber.
        /// </summary>
        /// <returns></returns>
        ISubscribeClient CreateSubscriber();

        /// <summary>
        /// Cleanup for factories created by SDK (either internal or external)
        /// </summary>
        void SDKCleanup();
    }
}