#if __cplusplus         // for cpp service definition
#pragma once
#else
using System;

namespace Layer0
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
        SERVICE_HOST,
        DOWNLOADMANAGER,
        HTTP_LISTENER,
        HTTP_SUBSCRIBE,
        DEVELOPER_MODE,
        L2FORWARDER,
        MEDIA,

        LOW_POWER_END,
        #endregion

        #region High power services
        HIGH_POWER_START = 1001,

        L0SETTINGSYSTEM_EXTERNAL,
        L0SETTINGSYSTEM_INTERNAL,
        //GSSERVICE,
        USER_SERVICE_INTERNAL,
        USER_SERVICE_EXTERNAL,
        BCSERVICE,
        INPUTMANAGER_INTERNAL,
        INPUTMANAGER_EXTERNAL,
        L10NSERVICE,
        OVERLAYMANAGER_INTERNAL,

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
        // Notice: we treat worker and service as the same mostly in layer0 because currently one service only got one worker.
        public static string WorkerID(this ServiceIDs swi)
        {
            return "WRK_" + swi.ToString();
        }

        public static string ForwarderID(this ServiceIDs swi)
        {
            return "FWD_" + swi.ToString();
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
            return "service/" + swi.ToString().ToLower();
        }

        public static bool ExistForwarder(this ServiceIDs swi)
        {
            switch(swi)
            {
                case ServiceIDs.HTTP_LISTENER:
                case ServiceIDs.SYS_REPORTER:
                case ServiceIDs.SERVICE_HOST:
                    return false;

                default:
                    return true;
            }
        }

        public static bool ExistWorker(this ServiceIDs swi)
        {
            switch(swi)
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



