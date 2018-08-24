using System.Diagnostics;

namespace Ruyi
{
    public class SDKUtility
    {
        public static SDKUtility Instance { get; } = new SDKUtility();

        public int LowLatencyTimeout => Debugger.IsAttached ? 6000000 : 20000;

        public int HighLatencyTimeout => Debugger.IsAttached ? 6000000 : 40000;
    }
}
