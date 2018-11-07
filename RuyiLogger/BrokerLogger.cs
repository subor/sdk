using Ruyi.Logging;

namespace Ruyi.Layer0
{
    public class BrokerLogger
    {
        static public void LogRequest(string msg, string source, string target, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Request,
                MsgSource = source,
                Level = lv,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }
        static public void LogReply(string msg, string source, string target, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Reply,
                MsgSource = source,
                Level = lv,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Debug(string msg, string source = "Broker", string target = "")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Debug,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Info(string msg, string source = "Broker", string target = "")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Info,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Warn(string msg, string source = "Broker", string target = "")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Warn,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Error(string msg, string source = "Broker", string target = "")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Error,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Fatal(string msg, string source = "Broker", string target = "")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Fatal,
                MsgTarget = target,
                Message = msg
            };

            Logger.Log(lm);
        }
    }
}
