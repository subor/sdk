using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Ruyi.SDK.CommonType;

namespace Ruyi
{
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
        /// <param name="result">The json string from server</param>
        /// <param name="fcGetErrMsg">Function used to get error message. Return (errorId, errorMessage)</param>
        /// <param name="moduleName">The caller module name</param>
        /// <param name="callback">The callback function to call before throwing the error</param>
        /// <param name="args">Argument passed to the error message</param>
        /// <returns></returns>
        public static JToken CheckJsonResult( string result, Func<(int, string)> fcGetErrMsg, string moduleName,
            Action<ErrorException> callback = null, params object[] args )
        {
            JToken retJson = null;

            bool bThrowError = false;
            if (string.IsNullOrEmpty(result))
            {
                bThrowError = true;
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
                    bThrowError = true;
                }
            }

            if (bThrowError)
            {
                var err = new ErrorException();
                (var errId, var errMsg) = fcGetErrMsg();

                err.ErrId = errId;

                if ( !string.IsNullOrEmpty(errMsg) )
                {
                    if (args == null || args.Length == 0)
                    {
                        err.ErrMsg = errMsg;
                    }
                    else
                    {
                        err.ErrMsg = string.Format(errMsg, args);
                    }
                }
                else
                {
                    err.ErrMsg = "Unknown error code: " + errId;
                }

                if (retJson != null)
                {
                    err.ErrMsg += string.Format("\n\tDetail: BCErr_{0}: {1}", retJson.Value<string>("reason_code"), retJson.Value<string>("status_message"));
                }

                callback?.Invoke(err);

                throw err;
            }

            return retJson;
        }
    }
}
