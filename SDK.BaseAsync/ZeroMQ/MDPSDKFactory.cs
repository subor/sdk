//using MajordomoProtocol;
using NetMQ;
using Ruyi.Logging;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Ruyi.Layer0.ZeroMQ
{
    public class MDPSDKFactory : ISDKFactory
    {
        public MDPSDKFactory(string pubsubInUri, string pubsubOutUri)
        {
            PublisherInUri = pubsubInUri;
            PublisherOutUri = pubsubOutUri;
        }

        //public IPublishEndpoint CreatePublisher(string topic)
        //{
        //    return PublishEndPoint.CreateInstance(topic, PublisherInUri);
        //}

        public ISubscribeClient CreateSubscriber()
        {
            return SubscribeClient.CreateInstance(PublisherOutUri);
        }

        public void SDKCleanup()
        {
            var entry = Assembly.GetEntryAssembly();
            if (entry == null)  // in a unit test
            {
                NetMQConfig.Cleanup(false);
                return;
            }

            // not Layer0 & not Layer1
            if (!entry.FullName.StartsWith("Layer0,", StringComparison.OrdinalIgnoreCase)
                && !entry.FullName.StartsWith("Layer1,", StringComparison.OrdinalIgnoreCase))
            {
                NetMQConfig.Cleanup(false);
                return;
            }
        }

        protected string PublisherInUri { get; private set; }
        protected string PublisherOutUri { get; private set; }
    }
    
}