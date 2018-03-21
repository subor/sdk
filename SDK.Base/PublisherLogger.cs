using RuyiLogger;

namespace Layer0
{
    public class PublisherLogger
    {
        static public void LogSubscriber(string msg, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Subscriber;
            lm.MsgSource = source;
            lm.Level = lv;
            lm.Topic = topic;
            lm.Message = msg;

            Logger.Log(lm);
        }
        static public void LogPublisher(string msg, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Publisher;
            lm.MsgSource = source;
            lm.Level = lv;
            lm.Topic = topic;
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Debug(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Debug;
            lm.Topic = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Info(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Info;
            lm.Topic = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Warn(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Warn;
            lm.Topic = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Error(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Error;
            lm.Topic = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Fatal(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Fatal;
            lm.Topic = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

    }
}
