#if __cplusplus         // for cpp service definition
#pragma once
#else
using System;
using System.Collections.Generic;

namespace Ruyi.Layer0
{
    public
#endif

    enum ServiceIDs
    {
        #region Low power services
        LOW_POWER_START = 101,

        VALIDATOR,
        LAUNCHER,
        POWERMANAGER,
        APPSYSTEM,
        STORAGELAYER,
        STORAGELAYER_INTERNAL,
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

        LOW_POWER_END,
        #endregion

        #region High power services
        HIGH_POWER_START = 1001,

        SETTINGSYSTEM_EXTERNAL,
        SETTINGSYSTEM_INTERNAL,
        USER_SERVICE_INTERNAL,
        USER_SERVICE_EXTERNAL,
        BCSERVICE,
        INPUTMANAGER_INTERNAL,
        INPUTMANAGER_EXTERNAL,
        L10NSERVICE,
        OVERLAYMANAGER_INTERNAL,
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
    public static class ServiceHelper
    {
        static Dictionary<ServiceIDs, string> shortNames = new Dictionary<ServiceIDs, string>();

        // Notice: we treat worker and service as the same mostly in layer0 because currently one service only got one worker.
        public static string WorkerID(this ServiceIDs swi)
        {
            return "WRK_" + swi.ShortString();
        }

        public static string ForwarderID(this ServiceIDs swi)
        {
            return "FWD_" + swi.ShortString();
        }

        #region string <-> serviceID convertion
        public static string ServiceID(this ServiceIDs swi)
        {
            return "SER_" + swi.ToString();
        }
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

        public static string PubChannelID(this ServiceIDs swi)
        {
            return "service/" + swi.ShortString().ToLower();
        }

        public static string ShortString(this ServiceIDs swi)
        {
            if(!shortNames.ContainsKey(swi))
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

        public static bool ExistForwarder(this ServiceIDs swi)
        {
            switch (swi)
            {
                case ServiceIDs.HTTP_LISTENER:
                case ServiceIDs.SYS_REPORTER:
                case ServiceIDs.L2FORWARDER:
                case ServiceIDs.LAYER1:
                    return false;

                default:
                    return true;
            }
        }

        public static bool IsLayer1Service(this ServiceIDs sid)
        {
            switch(sid)
            {
                case ServiceIDs.INPUTMANAGER_INTERNAL:
                case ServiceIDs.INPUTMANAGER_EXTERNAL:
                case ServiceIDs.LAUNCHER:
                    return true;
            }
            return false;
        }

        public static bool IsSplitter(this ServiceIDs sid)
        {
            if (sid == ServiceIDs.LOW_POWER_START || sid == ServiceIDs.LOW_POWER_END
                || sid == ServiceIDs.HIGH_POWER_START || sid == ServiceIDs.HIGH_POWER_END
                || sid == ServiceIDs.OPTIONAL_HIGH_POWER_START || sid == ServiceIDs.OPTIONAL_HIGH_POWER_END)
                return true;

            return false;
        }

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

    public static class AddressHelper
    {
        public static string SetAddress(this string config, string addr)
        {
            return config.Replace("{addr}", addr);
        }
    }

}
#endif



