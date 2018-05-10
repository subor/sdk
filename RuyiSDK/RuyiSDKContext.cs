using System.ComponentModel;
using Thrift.Transport;

namespace Ruyi
{
    /// <summary>
    /// context used to create RuyiSDK instance
    /// </summary>
    public class RuyiSDKContext
    {
        /// <summary>
        /// from which endpoint the SDK is running.
        /// </summary>
        public enum Endpoint
        {
            /// <summary>
            /// default to notset
            /// </summary>
            Notset,
            /// <summary>
            /// running from console
            /// </summary>
            Console,
            /// <summary>
            /// running from mobile
            /// </summary>
            Mobile,
            /// <summary>
            /// running from pc
            /// </summary>
            PC,
            /// <summary>
            /// running from web
            /// </summary>
            Web,
        }

        /// <summary>
        /// set the running end point
        /// </summary>
        public Endpoint endpoint = Endpoint.Notset;

        /// <summary>
        /// remote address of layer0
        /// </summary>
        public string RemoteAddress { get; set; } = "localhost";

        /// <summary>
        /// Specify which SDK features should be enabled.  Default is all features enabled.
        /// </summary>
        public RuyiSDK.SDKFeatures EnabledFeatures { get; set; } = RuyiSDK.SDKFeatures.All;

        /// <summary>
        /// Port to connect to for low-latency messages.  Leave as zero to use default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public int LowLatencyPort = 0;
        /// <summary>
        /// Port to connect to for high-latency messages.  Leave as zero to use default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public int HighLatencyPort = 0;

        /// <summary>
        /// Thrift transport to use.  If null will initialize default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TTransport Transport;

        /// <summary>
        /// Timeout (in ms) for connections.  If less than or equal to 0, use default.
        /// </summary>
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// validation check
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (endpoint == Endpoint.Notset)
                return false;

            return true;
        }
    }
}
