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
        /// <summary>
        /// if the message is stopped
        /// </summary>
        /// <param name="msg">the message used</param>
        static public bool IsStoppingMessage(NetMQMessage msg)
        {
            if (msg.FrameCount == 4 && msg[3].ConvertToString() == stoppingKey)
                return true;
            return false;
        }
        #endregion
    }
}
