using Ruyi.Layer0;
using NetMQ;
using Ruyi.SDK.Online;
using Ruyi.SDK.Constants;
using Ruyi.SDK.LocalizationService;
using Ruyi.SDK.MediaService;
using Ruyi.SDK.Speech;
using Ruyi.SDK.StorageLayer;
using Ruyi.SDK.UserServiceExternal;
using Ruyi.SDK.SDKValidator;
using Ruyi.Logging;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Thrift.Protocol;
using Thrift.Transport;

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
            All = Basic | Storage | L10N | Speech | Media,
        }

        /// <summary>
        /// to subscribe to a topic
        /// </summary>
        public SubscribeClient Subscriber { get; private set; }

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

        //public InputMgrExternal.Client InputMgr { get; private set; }

        public SpeechService.Client SpeechService { get; private set;}

        /// <summary>
        /// Media player services
        /// </summary>
        public MediaService.Client Media { get; private set; }

        private RuyiSDKContext context = null;

        private TTransport lowLatencyTransport = null;
        /// <summary>
        /// Underlying transport and protocol for low-latency messages
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TBinaryProtocolTS LowLatencyProtocol { get; private set; }

        private TTransport highLatencyTransport = null;
        /// <summary>
        /// Underlying transport and protocol for high-latency messages
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TBinaryProtocolTS HighLatencyProtocol { get; private set; }

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
            if (context.Transport == null)
            {
                // If debugger attached don't want messages to timeout
                var timeout = System.Diagnostics.Debugger.IsAttached ? 600000
                    : (context.Timeout <= 0 ? 10000 : context.Timeout);

                // init and open high/low latency transport, create protocols
                var lowLatencyPort = context.LowLatencyPort == 0 ? ConstantsSDKDataTypesConstants.low_latency_socket_port : context.LowLatencyPort;
                lowLatencyTransport = new TSocketTransportTS(context.RemoteAddress, lowLatencyPort, timeout);

                var highLatencyPort = context.HighLatencyPort == 0 ? ConstantsSDKDataTypesConstants.high_latency_socket_port : context.HighLatencyPort;
                highLatencyTransport = new TSocketTransportTS(context.RemoteAddress, highLatencyPort, timeout);
            }
            else
            {
                lowLatencyTransport = context.Transport;
                highLatencyTransport = context.Transport;
            }

            LowLatencyProtocol = new TBinaryProtocolTS(lowLatencyTransport);
            HighLatencyProtocol = new TBinaryProtocolTS(highLatencyTransport);

            lowLatencyTransport.Open();
            highLatencyTransport.Open();

            if (!ValidateVersion())
                return false;

            // init subscriber
            if (IsFeatureEnabled(SDKFeatures.Subscriber))
            {
                var pubout = ConstantsSDKDataTypesConstants.layer0_publisher_out_uri.SetAddress(context.RemoteAddress);
                Subscriber = SubscribeClient.CreateInstance(pubout);
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
                var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.L0SETTINGSYSTEM_EXTERNAL.ServiceID());
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

            //// input manger
            //if ( IsFeatureEnabled(Features.Input) )
            //{
            //    var proto = new TMultiplexedProtocol(LowLatencyProtocol, ServiceIDs.INPUTMANAGER_EXTERNAL.ServiceID());
            //    InputMgr = new InputMgrExternal.Client(proto);
            //}

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
            string valid = validator.ValidateSDK(ver.ToString());
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

            //InputMgr?.Dispose();
            //InputMgr = null;

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
                var entry = Assembly.GetEntryAssembly();
                if (entry == null)  // in a unit test
                {
                    NetMQConfig.Cleanup(false);
                    return;
                }

                // not Layer0
                var attrs = entry.GetCustomAttributes(false).OfType<GuidAttribute>();
                if (!(attrs.Any() && attrs.First().Value.Equals("a9a38292-d200-4ee3-885c-726aa6da08ee")))
                {
                    NetMQConfig.Cleanup(false);
                    return;
                }
            }
        }
    }
}
