using System.Diagnostics;

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
    }
}
