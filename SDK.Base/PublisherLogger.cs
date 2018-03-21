using RuyiLogger;

namespace Layer0
{
    public class PublisherLogger
    {
        static public void LogSubscriber(string msg, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Subscriber;
            lm.MsgSource = source;
            lm.level = lv;
            lm.Topic = topic;
            lm.message = msg;

            Logger.Log(lm);
        }
        static public void LogPublisher(string msg, string source, string topic, LogLevel lv = LogLevel.Debug)
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Publisher;
            lm.MsgSource = source;
            lm.level = lv;
            lm.Topic = topic;
            lm.message = msg;

            Logger.Log(lm);
        }

        static public void Debug(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.level = LogLevel.Debug;
            lm.Topic = "";
            lm.message = msg;

            Logger.Log(lm);
        }

        static public void Info(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.level = LogLevel.Info;
            lm.Topic = "";
            lm.message = msg;

            Logger.Log(lm);
        }

        static public void Warn(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.level = LogLevel.Warn;
            lm.Topic = "";
            lm.message = msg;

            Logger.Log(lm);
        }

        static public void Error(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.level = LogLevel.Error;
            lm.Topic = "";
            lm.message = msg;

            Logger.Log(lm);
        }

        static public void Fatal(string msg, string source = "publisher")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.level = LogLevel.Fatal;
            lm.Topic = "";
            lm.message = msg;

            Logger.Log(lm);
        }

    }
}
