using Ruyi.Logging;

namespace Ruyi.Layer0
{
    static public class TRCChecker
    {
        static public void Publish(string source, string msg)
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.TRC,
                MsgSource = source,
                Level = LogLevel.Debug,
                Topic = source,
                Message = msg
            };

            Logger.Log(lm);
        }
    }
}
