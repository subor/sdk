using Ruyi.Logging;

namespace Ruyi.Layer0
{
    /// <summary>
    /// public logger class
    /// </summary>
    public class PublisherLogger
    {
        /// <summary>
        /// the Category of log is Subscriber
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="type">C# type of the message, could use it for reflection purposes</param>
        /// <param name="source">Where the message comes from</param>
        /// <param name="topic">Alias for MsgTarget</param>
        /// <param name="lv">The log level</param>
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

        /// <summary>
        /// the Category of log is Publisher
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="type">C# type of the message, could use it for reflection purposes</param>
        /// <param name="source">Where the message comes from</param>
        /// <param name="topic">Alias for MsgTarget</param>
        /// <param name="lv">The log level</param>
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

        /// <summary>
        /// the level of log is Debug 
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="source">Where the message comes from</param>
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

        /// <summary>
        /// the level of log is Info
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="source">Where the message comes from</param>
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

        /// <summary>
        /// the level of log is Warn
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="source">Where the message comes from</param>
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

        /// <summary>
        /// the level of log is Error
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="source">Where the message comes from</param>
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

        /// <summary>
        /// the level of log is Fatal
        /// </summary>
        /// <param name="msg">message to log</param>
        /// <param name="source">Where the message comes from</param>
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
