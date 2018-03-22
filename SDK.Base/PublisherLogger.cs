using RuyiLogger;

namespace Layer0
{
    public class PublisherLogger
    {
        static public void LogSubscriber(string msg, string type, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Subscriber,
                MsgSource = source,
                MsgType = type,
                Level = lv,
                Topic = topic,
                Message = msg
            };

            Logger.Log(lm);
        }
        static public void LogPublisher(string msg, string type, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Publisher,
                MsgSource = source,
                MsgType = type,
                Level = lv,
                Topic = topic,
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Debug(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Debug,
                Topic = "",
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Info(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Info,
                Topic = "",
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Warn(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Warn,
                Topic = "",
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Error(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Error,
                Topic = "",
                Message = msg
            };

            Logger.Log(lm);
        }

        static public void Fatal(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage
            {
                Category = MessageCategory.Framework,
                MsgSource = source,
                Level = LogLevel.Fatal,
                Topic = "",
                Message = msg
            };

            Logger.Log(lm);
        }

    }
}
