using Ruyi.Layer0;
using Ruyi.Logging;
using Ruyi.SDK.Constants;
using Ruyi.SDK.LocalizationService;
using Ruyi.SDK.MediaService;
using Ruyi.SDK.Online;
using Ruyi.SDK.SDKValidator;
using Ruyi.SDK.Speech;
using Ruyi.SDK.StorageLayer;
using Ruyi.SDK.UserServiceExternal;
using Ruyi.SDK.InputManager;
using Ruyi.SDK.OverlayManagerExternal;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace Ruyi
{
    /// <summary>
    /// the main class used to communicate with the Ruyi platform
    /// </summary>
    public class RuyiSDK : IDisposable
    {
        /// <summary>
        /// Flags specifying which SDK features to initialize
        /// </summary>
        [Flags]
        public enum SDKFeatures
        {
            /// <summary>
            /// No SDK features
            /// </summary>
            None = 0,
            /// <summary>
            /// Storage layer
            /// </summary>
            Storage = 1 << 0,
            /// <summary>
            /// Localization service
            /// </summary>
            L10N = 1 << 1,
            /// <summary>
            /// RuyiNet online platform
            /// </summary>
            Online = 1 << 2,
            /// <summary>
            /// Settings system
            /// </summary>
            Settings = 1 << 3,
            /// <summary>
            /// User service
            /// </summary>
            Users = 1 << 4,
            /// <summary>
            /// Input Manager
            /// </summary>
            Input = 1 << 5,
            /// <summary>
            /// Speech
            /// </summary>
            Speech = 1 << 6,
            /// <summary>
            /// Media player service
            /// </summary>
            Media = 1 << 7,
            /// <summary>
            /// Overlay service
            /// </summary>
            Overlay = 1<<8 ,
            /// <summary>
            /// Initialize subscriber for publisher/subscriber messaging
            /// </summary>
            Subscriber = 1 << 16,

            /// <summary>
            /// Most important SDK features (key layer0 services)
            /// </summary>
            Basic = Online | Settings | Users | Input | Subscriber,

            /// <summary>
            /// All SDK features
            /// </summary>
            All = Basic | Storage | L10N | Speech | Media | Overlay,
        }

        /// <summary>
        /// to subscribe to a topic
        /// </summary>
        public ISubscribeClient Subscriber { get; private set; }

        /// <summary>
        /// to access the ruyi platform storage interface
        /// </summary>
        public StorageLayerService.Client Storage { get; private set; }

        /// <summary>
        /// to access the l10n service from Ruyi
        /// </summary>
        public LocalizationService.Client L10NService { get; private set; }

        /// <summary>
        /// to access the ruyi platform back end service interface
        /// </summary>
        public RuyiNetClient RuyiNetService { get; private set; }

        /// <summary>
        /// to access the setting system
        /// </summary>
        public SDK.SettingSystem.Api.SettingSystemService.Client SettingSys { get; private set; }

        /// <summary>
        /// User-related services
        /// </summary>
        public UserServExternal.Client UserService { get; private set; }

        /// <summary>
        /// Input related services
        /// </summary>
        public InputManagerService.Client InputMgr { get; private set; }

        /// <summary>
        /// the speech service
        /// </summary>
        public SpeechService.Client SpeechService { get; private set; }

        /// <summary>
        /// the overlay service
        /// </summary>
        public ExternalOverlayManagerService.Client OverlayService { get; private set; }

        /// <summary>
        /// Media player services
        /// </summary>
        public MediaService.Client Media { get; private set; }

        private RuyiSDKContext context = null;

        private TClientTransport lowLatencyTransport = null;
        /// <summary>
        /// Underlying transport and protocol for low-latency messages
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TProtocol LowLatencyProtocol { get; private set; }

        private TClientTransport highLatencyTransport = null;
        /// <summary>
        /// Underlying transport and protocol for high-latency messages
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TProtocol HighLatencyProtocol { get; private set; }

        private ValidatorService.Client validator = null;

        static private int InstanceCount = 0;

        private RuyiSDK() { }

        /// <summary>
        /// Create a new SDK instance with the given context.
        /// </summary>
        /// <param name="cont">context used to create the sdk instance</param>
        /// <returns>the created instance, null if context is not valid</returns>
        public static RuyiSDK CreateInstance(RuyiSDKContext cont)
        {
            if (cont == null || !cont.IsValid())
            {
                throw new Exception("Invalid SDKContext, you need to set all the context values.");
            }

            RuyiSDK ret = new RuyiSDK
            {
                context = cont
            };

            InstanceCount++;
            if (!ret.Init())
            {
                ret.Dispose();
                return null;
            }

            return ret;
        }

        bool Init()
        {
            // Default to using binary protocol
            Func<TClientTransport, TProtocol> createProtocolFunc = (transport) => new TBinaryProtocolTS(transport);

            if (context.Transport == null)
            {
                if (context.endpoint == RuyiSDKContext.Endpoint.Web)
                {
                    lowLatencyTransport = new THttpClientTransport(new Uri(context.RemoteAddress), null);
                    highLatencyTransport = lowLatencyTransport;
                    createProtocolFunc = (transport) => new TJsonProtocol(transport);
                }
                else
                {
                    var host = OS.Util.GetIPAddress(context.RemoteAddress);
                    // init and open high/low latency transport, create protocols
                    var lowLatencyPort = context.LowLatencyPort == 0 ? ConstantsSDKDataTypesConstants.low_latency_socket_port : context.LowLatencyPort;
                    lowLatencyTransport = new TSocketTransportTS(host, lowLatencyPort, context.Timeout <= 0 ? SDKUtility.Instance.LowLatencyTimeout : context.Timeout);

                    var highLatencyPort = context.HighLatencyPort == 0 ? ConstantsSDKDataTypesConstants.high_latency_socket_port : context.HighLatencyPort;
                    highLatencyTransport = new TSocketTransportTS(host, highLatencyPort, context.Timeout <= 0 ? SDKUtility.Instance.HighLatencyTimeout : context.Timeout);
                }
            }
            else
            {
                lowLatencyTransport = context.Transport;
                highLatencyTransport = context.Transport;
            }

            // If we have 1 transport we need 1 protocol, if 2 transports 2 protocol
            if (Object.ReferenceEquals(lowLatencyTransport, highLatencyTransport))
            {
                LowLatencyProtocol = createProtocolFunc(lowLatencyTransport);
                HighLatencyProtocol = LowLatencyProtocol;
                lowLatencyTransport.OpenAsync().Wait();
            }
            else
            {
                LowLatencyProtocol = createProtocolFunc(lowLatencyTransport);
                HighLatencyProtocol = createProtocolFunc(highLatencyTransport);

                Task.WaitAll(
                    lowLatencyTransport.OpenAsync(),
                    highLatencyTransport.OpenAsync()
                    );
            }

            if (!ValidateVersion())
                return false;

            var pubout = ConstantsSDKDataTypesConstants.layer0_publisher_out_uri.SetAddress(context.RemoteAddress);
            factory = new MDPSDKFactory(pubout);

            // init subscriber
            if (context.endpoint != RuyiSDKContext.Endpoint.Web && IsFeatureEnabled(SDKFeatures.Subscriber))
            {
                Subscriber = factory.CreatePubSubClient();
            }

            // init storage layer
            if (IsFeatureEnabled(SDKFeatures.Storage))
            {
                var stoProtocol = new TMultiplexedProtocol(HighLatencyProtocol, ServiceIDs.STORAGELAYER.ServiceID());
                Storage = new StorageLayerService.Client(stoProtocol);
            }

            // init braincloud service
            if (IsFeatureEnabled(SDKFeatures.Online))
            {
                var bcProtocol = new TMultiplexedProtocol(HighLatencyProtocol, ServiceIDs.BCSERVICE.ServiceID());
                RuyiNetService = new RuyiNetClient(bcProtocol, Storage);
                //BCService = new BrainCloudService.Client(bcProtocal);
            }

            // init setting system
            if (IsFeatureEnabled(SDKFeatures.Settings))
            {
                var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.SETTINGSYSTEM_EXTERNAL.ServiceID());
                SettingSys = new SDK.SettingSystem.Api.SettingSystemService.Client(proto);
            }

            // init L10N
            if (IsFeatureEnabled(SDKFeatures.L10N))
            {
                var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.L10NSERVICE.ServiceID());
                L10NService = new LocalizationService.Client(proto);
            }

            // user manager
            if (IsFeatureEnabled(SDKFeatures.Users))
            {
                var proto = new TMultiplexedProtocol(HighLatencyProtocol, ServiceIDs.USER_SERVICE_EXTERNAL.ServiceID());
                UserService = new UserServExternal.Client(proto);
            }

            // input manger
            if (IsFeatureEnabled(SDKFeatures.Input))
            {
                var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.INPUTMANAGER_EXTERNAL.ServiceID());
                InputMgr = new InputManagerService.Client(proto);
            }

            if (IsFeatureEnabled(SDKFeatures.Speech))
            {
                var proto = new TMultiplexedProtocol(HighLatencyProtocol, ServiceIDs.SPEECH.ServiceID());
                SpeechService = new SpeechService.Client(proto);
            }

            if (IsFeatureEnabled(SDKFeatures.Media))
            {
                var proto = new TMultiplexedProtocol(HighLatencyProtocol, ServiceIDs.MEDIA.ServiceID());
                Media = new MediaService.Client(proto);
            }
            if (IsFeatureEnabled(SDKFeatures.Overlay))
            {
                var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.OVERLAYMANAGER_EXTERNAL.ServiceID());
                OverlayService = new ExternalOverlayManagerService.Client(proto);
            }
            return true;
        }

        bool IsFeatureEnabled(SDKFeatures fea)
        {

#if NET20
            return ((int)context.EnabledFeatures & (int)fea) != 0;
#else
            return context.EnabledFeatures.HasFlag(fea);
#endif
        }

        bool ValidateVersion()
        {
            // Do version check with layer0
            Version ver = Assembly.GetAssembly(GetType()).GetName().Version;
            var validationProtocol = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.VALIDATOR.ServiceID());
            validator = new ValidatorService.Client(validationProtocol);
            string valid = validator.ValidateSDKAsync(ver.ToString(), CancellationToken.None).Result;
            if (valid.StartsWith("err:"))
            {
                Logger.Log(new LoggerMessage()
                {
                    Level = LogLevel.Fatal,
                    MsgSource = "SDK",
                    Message = $"SDK version {ver} != ruyi version: {valid}"
                });
                return false;
            }
            else if (valid.StartsWith("warn:"))
            {
                Logger.Log(new LoggerMessage()
                {
                    Level = LogLevel.Warn,
                    MsgSource = "SDK",
                    Message = $"SDK version {ver} != ruyi version: {valid}",
                });
            }
            else
            {
                Logger.Log(new LoggerMessage()
                {
                    Level = LogLevel.Info,
                    MsgSource = "SDK",
                    Message = "SDK version validated.",
                });
            }

            return true;
        }

        /// <summary>
        /// Basic update loop.
        /// </summary>
        public void Update()
        {
            RuyiNetService.Update();
        }

        /// <summary>
        /// Dispose the SDK instance, don't miss this after SDK usage.
        /// </summary>
        public void Dispose()
        {
            Subscriber?.Dispose();
            Subscriber = null;

            Storage?.Dispose();
            Storage = null;

            RuyiNetService?.Dispose();
            RuyiNetService = null;

            SettingSys?.Dispose();
            SettingSys = null;

            L10NService?.Dispose();
            L10NService = null;

            UserService?.Dispose();
            UserService = null;

            InputMgr?.Dispose();
            InputMgr = null;

            SpeechService?.Dispose();
            SpeechService = null;

            Media?.Dispose();
            Media = null;

            OverlayService?.Dispose();
            OverlayService = null;

            lowLatencyTransport?.Close();
            LowLatencyProtocol?.Dispose();
            lowLatencyTransport = null;
            LowLatencyProtocol = null;

            highLatencyTransport?.Close();
            HighLatencyProtocol?.Dispose();
            HighLatencyProtocol = null;
            highLatencyTransport = null;


            // don't clean up netmq in layer0.
            InstanceCount--;
            if (InstanceCount <= 0)
            {
                factory.Cleanup();
            }
        }

        ISDKFactory factory;
    }
}
