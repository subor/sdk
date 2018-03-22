using System;

namespace RuyiLogger
{
    public enum MessageCategory
    {
        Unknown = 0,
        Request,
        Reply,
        Publisher,
        Subscriber,
        /// <summary>
        /// Message comes from the running framework aka layer0
        /// </summary>
        Framework,
        Layer0 = Framework,
        /// <summary>
        /// TRC message
        /// </summary>
        TRC,
        MainClient
    }

    public enum LogLevel
    {
        Debug = 0x10,
        Info = 0x20,
        Warn = 0x30,
        Error = 0x40,
        Fatal = 0x50,
    }

    public class LoggerMessage
    {
        /// <summary>
        /// The log level
        /// </summary>
        public LogLevel Level { get; set; } = LogLevel.Debug;
        /// <summary>
        /// The message category
        /// </summary>
        public MessageCategory Category { get; set; } = MessageCategory.Unknown;
        /// <summary>
        /// Where the message comes from
        /// </summary>
        public string MsgSource { get; set; }
        /// <summary>
        /// Target service or topic, according to the eventType
        /// </summary>
        public string MsgTarget { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// C# type of the message, could use it for reflection purposes
        /// </summary>
        public string MsgType { get; set; }
        public DateTime Date { get; set; }

        public LoggerMessage()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// Alias for MsgTarget
        /// </summary>
        public string Topic
        {
            get { return MsgTarget; }
            set { MsgTarget = value; }
        }

        public LoggerMessage(LoggerMessage lm)
        {
            Level = lm.Level;
            Category = lm.Category;
            MsgSource = lm.MsgSource;
            MsgTarget = lm.MsgTarget;
            Message = lm.Message;
            MsgType = lm.MsgType;
            Date = lm.Date;
        }

        override public string ToString()
        {
            return $"[{Category,10}]\t[{MsgSource,10}]\t[{MsgTarget,10}]\t{Message}";
        }

        public string ToPluginString()
        {
            return $"[{Date,10}]\t[{MsgSource,20}]\t[{Level,10}]\t{Message}";
        }
    }
}
