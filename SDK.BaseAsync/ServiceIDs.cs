#if __cplusplus         // for cpp service definition
#pragma once
#else
using System;
using System.Collections.Generic;

namespace Ruyi.Layer0
{
    /// <summary>
    /// Service Id enum class
    /// </summary>
    public
#endif

    enum ServiceIDs
    {
        #region Low power services
        LOW_POWER_START = 101,

        VALIDATOR,
        LAUNCHER,
        POWERMANAGER,
        POWERMANAGER_INTERNAL,
        APPSYSTEM,
        STORAGELAYER,
        STORAGELAYER_INTERNAL,
        INPUTMANAGER_INTERNAL,
        INPUTMANAGER_EXTERNAL,
        SYS_REPORTER,
        DOWNLOADMANAGER,
        HTTP_LISTENER,
        HTTP_SUBSCRIBE,
        DEVELOPER_MODE,
        L2FORWARDER,
        IOT_BLUETOOTH,
        SPEECH,
        MEDIA,
        LAYER1,
        NOTIFICATION,
        SECURITY,

        LOW_POWER_END,
        #endregion

        #region High power services
        HIGH_POWER_START = 1001,

        SETTINGSYSTEM_EXTERNAL,
        SETTINGSYSTEM_INTERNAL,
        SETTINGSYSTEM_LAYER1,
        USER_SERVICE_INTERNAL,
        USER_SERVICE_EXTERNAL,
        BCSERVICE,
        L10NSERVICE,
        OVERLAYMANAGER_INTERNAL,
        OVERLAYMANAGER_EXTERNAL,
        UPDATESERVICE,
#if DEBUG
        TEST,
#endif

        HIGH_POWER_END,
        #endregion

        #region Optional high power
        OPTIONAL_HIGH_POWER_START = 2001,

        L0_DEBUGGER,
        TRC_DEBUGGER,
        OPTIONAL_HIGH_POWER_END,
        #endregion
    }

#if !__cplusplus            // C#, some helper functions
    /// <summary>
    /// service Helper class
    /// </summary>
    public static class ServiceHelper
    {
        static Dictionary<ServiceIDs, string> shortNames = new Dictionary<ServiceIDs, string>();
        static object locker = new object();

        /// <summary>
        /// work ID of the service
        /// Notice: we treat worker and service as the same mostly in layer0 because currently one service only got one worker.
        /// </summary>
        /// <param name="swi">the service ID</param>
        /// <returns></returns>
        public static string WorkerID(this ServiceIDs swi)
        {
            return "WRK_" + swi.ShortString();
        }

        /// <summary>
        /// forwarder ID of the service
        /// </summary>
        /// <param name="swi">the service ID</param>
        /// <returns></returns>
        public static string ForwarderID(this ServiceIDs swi)
        {
            return "FWD_" + swi.ShortString();
        }

        #region string <-> serviceID convertion
        /// <summary>
        /// string convertion of service ID
        /// </summary>
        /// <param name="swi">the service ID</param>
        /// <returns>the string of the service ID</returns>
        public static string ServiceID(this ServiceIDs swi)
        {
            return "SER_" + swi.ToString();
        }

        /// <summary>
        /// service ID from string
        /// </summary>
        /// <param name="ser">the string of service ID</param>
        /// <returns>the service ID from string</returns>
        public static ServiceIDs FromServiceIDStr(string ser)
        {
            try
            {
                var s = (ServiceIDs)Enum.Parse(typeof(ServiceIDs), ser.Substring(4));
                return s;
            }
            catch
            {
                throw new Exception($"service id {ser} not predefined in ServiceIDs");
            }
        }
        #endregion

        /// <summary>
        /// the service publish to topic
        /// </summary>
        /// <param name="swi">the service ID</param>
        public static string PubChannelID(this ServiceIDs swi)
        {
            return "service/" + swi.ShortString().ToLower();
        }

        /// <summary>
        /// short string of the service 
        /// </summary>
        /// <param name="swi">the service ID</param>
        public static string ShortString(this ServiceIDs swi)
        {
            lock (locker)
            {
                if (!shortNames.ContainsKey(swi))
                {
                    shortNames.Add(swi, swi.ToString()
                        .Replace("INTERNAL", "Int")
                        .Replace("EXTERNAL", "Ext")
                        .Replace("MANAGER", "Mgr")
                        .Replace("SERVICE", "Serv")
                        .Replace("SYSTEM", "Sys"));
                }
                return shortNames[swi];
            }

        }

        /// <summary>
        /// if the service exist 
        /// </summary>
        /// <param name="swi">the service ID</param>
        public static bool ExistForwarder(this ServiceIDs swi)
        {
            switch (swi)
            {
                case ServiceIDs.HTTP_LISTENER:
                case ServiceIDs.SYS_REPORTER:
                case ServiceIDs.L2FORWARDER:
                case ServiceIDs.LAYER1:
                case ServiceIDs.UPDATESERVICE:
                    return false;

                default:
                    return true;
            }
        }

        /// <summary>
        /// if the service belongto layer1
        /// </summary>
        /// <param name="sid">the service ID</param>
        public static bool IsLayer1Service(this ServiceIDs sid)
        {
            switch (sid)
            {
                case ServiceIDs.INPUTMANAGER_INTERNAL:
                case ServiceIDs.INPUTMANAGER_EXTERNAL:
                case ServiceIDs.LAUNCHER:
                case ServiceIDs.UPDATESERVICE:
                case ServiceIDs.POWERMANAGER:
                case ServiceIDs.SETTINGSYSTEM_LAYER1:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// if the service is a splitter service
        /// </summary>
        /// <param name="sid">the service ID</param>
        public static bool IsSplitter(this ServiceIDs sid)
        {
            if (sid == ServiceIDs.LOW_POWER_START || sid == ServiceIDs.LOW_POWER_END
                || sid == ServiceIDs.HIGH_POWER_START || sid == ServiceIDs.HIGH_POWER_END
                || sid == ServiceIDs.OPTIONAL_HIGH_POWER_START || sid == ServiceIDs.OPTIONAL_HIGH_POWER_END)
                return true;

            return false;
        }

        /// <summary>
        /// if the service exist
        /// </summary>
        /// <param name="swi">the service ID</param>
        public static bool ExistWorker(this ServiceIDs swi)
        {
            switch (swi)
            {
                case ServiceIDs.VALIDATOR:
                    return false;

                default:
                    return true;
            }
        }
    }

    /// <summary>
    /// Address helper class
    /// </summary>
    public static class AddressHelper
    {
        /// <summary>
        /// set address of SDk context instance
        /// </summary>
        /// <param name="config">the config string</param>
        /// <param name="addr">the address to fill in config</param>
        /// <example>
        /// var pubout = ConstantsSDKDataTypesConstants.layer0_publisher_out_uri.SetAddress(context.RemoteAddress);
        /// Subscriber = SubscribeClient.CreateInstance(pubout);
        /// </example>
        public static string SetAddress(this string config, string addr)
        {
            return config.Replace("{addr}", addr);
        }
    }

}
#endif



