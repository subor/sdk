using NetMQ;

namespace Layer0
{
    public class PubsubUtil
    {
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
}
