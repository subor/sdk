
namespace Ruyi.Layer0
{
    public interface ISDKFactory
    {
        ISubscribeClient CreatePubSubClient();
        void Cleanup();
    }
}