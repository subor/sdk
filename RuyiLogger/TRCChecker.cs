using RuyiLogger;

namespace Layer0
{
    static public class TRCChecker
    {
        static public void Publish(string source, string msg)
        {
            LoggerMessage lm = new LoggerMessage
            {
                category = MessageCategory.TRC,
                MsgSource = source,
                level = LogLevel.Debug,
                Topic = source,
                message = msg
            };

            Logger.Log(lm);
        }
    }
}
