using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Ruyi
{
    /// <summary>
    /// The common error class to describ an internal or external error
    /// </summary>
    public class RuyiErrorMessage
    {
        /// <summary>
        /// The id of the error
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The error message
        /// </summary>
        public string Msg { get; set; }
    }

    /// <summary>
    /// the common Utility class of SDK
    /// </summary>
    public class SDKUtility
    {
        /// <summary>
        /// static Instance of SDKUtility
        /// </summary>
        public static SDKUtility Instance { get; } = new SDKUtility();

        /// <summary>
        /// low latency timeout value
        /// </summary>
        public int LowLatencyTimeout => Debugger.IsAttached ? 6000000 : 20000;

        /// <summary>
        /// high latency timeout value
        /// </summary>
        public int HighLatencyTimeout => Debugger.IsAttached ? 6000000 : 40000;

        /// <summary>
        /// Check Json string return from server, and convert to json token
        /// </summary>
        /// <param name="retJson">The json token parsed from result</param>
        /// <param name="result">The json string from server</param>
        /// <param name="fcGetErrMsg">Function used to get error message</param>
        /// <param name="moduleName">The caller module name</param>
        /// <param name="args">Argument passed to the error message</param>
        /// <returns></returns>
        public static RuyiErrorMessage CheckJsonResult(out JToken retJson, string result, 
            Func<RuyiErrorMessage> fcGetErrMsg, string moduleName, params object[] args )
        {
            RuyiErrorMessage errMsg = null;
            retJson = null;

            bool bHasError = false;
            if (string.IsNullOrEmpty(result))
            {
                bHasError = true;
            }
            else
            {
                try
                {
                    retJson = JToken.Parse(result);
                }
                catch (Exception ex)
                {
                    Logging.Logger.Log($">>>>> {ex} {result}", Logging.LogLevel.Warn, Logging.MessageCategory.Layer0, moduleName);
                }
                if (retJson == null || retJson.Value<long>("status") != 200)
                {
                    bHasError = true;
                }
            }

            if (bHasError)
            {
                errMsg = fcGetErrMsg();

                if ( !string.IsNullOrEmpty(errMsg.Msg) )
                {
                    if (args != null && args.Length > 0)
                    {
                        errMsg.Msg = string.Format(errMsg.Msg, args);
                    }
                }
                else
                {
                    errMsg.Msg = "Unknown error code: " + errMsg.Id;
                }

                if (retJson != null)
                {
                    errMsg.Msg += string.Format("\n\tDetail: BCErr_{0}: {1}", retJson.Value<string>("reason_code"), retJson.Value<string>("status_message"));
                }
            }

            return errMsg;
        }
    }
}
