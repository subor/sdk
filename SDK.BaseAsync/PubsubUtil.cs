using NetMQ;

namespace Ruyi.Layer0
{
    public class PubsubUtil
    {
        /// <summary>
        /// Pub/sub topic used by the SDK
        /// </summary>
        public static string SDKTopic = "sdk";

        static string stoppingKey = "AKXBIHKE334KLEI0CVNLKEWDFITEWSD89LKFE8DKNVE8FEAF9043JG3KG83SJGF8";

        #region helper methods
        static public bool IsStoppingMessage(NetMQMessage msg)
        {
            if (msg.FrameCount == 4 && msg[3].ConvertToString() == stoppingKey)
                return true;
            return false;
        }
        #endregion
    }

    public sealed class PubSubUtil
    {
        public static readonly byte[] StopMsg = System.Text.Encoding.ASCII.GetBytes("258B00D9-820A-41B0-B991-953EDA18A398");

        public static bool IsStoppingMessage(byte[] msg)
        {
            System.Collections.IStructuralEquatable equ = msg;
            return equ.Equals(StopMsg, System.Collections.StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
