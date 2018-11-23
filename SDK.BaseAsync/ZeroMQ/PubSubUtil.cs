using NetMQ;

namespace Ruyi.Layer0.ZeroMQ
{
    public class PubSubUtil
    {
        const string stoppingKey = "258B00D9-820A-41B0-B991-953EDA18A398";
        static private NetMQMessage stopMsg = null;
        public static NetMQMessage StopMsg
        {
            get
            {
                if (stopMsg == null)
                {
                    stopMsg = new NetMQMessage();
                    stopMsg.Append("stop");
                    stopMsg.AppendEmptyFrame();
                    stopMsg.AppendEmptyFrame();
                    stopMsg.Append(stoppingKey);
                }
                return stopMsg;
            }
        }

        #region helper methods
        static public bool IsStoppingMessage(NetMQMessage msg)
        {
            if (msg.FrameCount == 4)
            {
                var key = msg[3].ConvertToString();
                if (key == stoppingKey)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
