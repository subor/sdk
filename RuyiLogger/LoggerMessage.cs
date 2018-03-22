using System;

namespace RuyiLogger
{
    public enum MessageCategory
    {
        Request,
        Reply,
        Publisher,
        Subscriber,
        Framework,      // message comes from the running framework aka layer0
        Layer0 = Framework,
        TRC,            // TRC message
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
        /// used by both MsgTarget & Topic
        /// </summary>
        protected string channel;              // target service or topic, according to the eventType

        /// <summary>
        /// log time
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// the c# type of the message, could use it for reflection purpose
        /// </summary>
        public string MsgType { get; set; } = "";
        
        /// <summary>
        /// where the message comes from
        /// </summary>
        public string MsgSource { get; set; } = "";
        
        /// <summary>
        /// belongs to which category
        /// </summary>
        public MessageCategory Category { get; set; }
        
        /// <summary>
        /// the level
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// where the message goes
        /// </summary>
        public string MsgTarget
        {
            get { return channel; }
            set { channel = value; }
        }

        /// <summary>
        /// the topic, will use the same segment with MsgTarget
        /// </summary>
        public string Topic
        {
            get { return channel; }
            set { channel = value; }
        }

        /// <summary>
        /// the message
        /// </summary>
        public string Message { get; set; }

        public LoggerMessage()
        {
            Date = DateTime.Now;
            Level = LogLevel.Debug;
        }

        public LoggerMessage(LoggerMessage lm)
        {
            Level = lm.Level;
            Category = lm.Category;
            MsgSource = lm.MsgSource;
            MsgType = lm.MsgType;
            channel = lm.channel;
            Message = lm.Message;
            Date = lm.Date;
        }

        override public string ToString()
        {
            return $"[{Category,10}]\t[{MsgSource,10}]\t[{channel,10}]\t{Message}";
        }

        public string ToPluginString()
        {
            return $"[{Date,10}]\t[{MsgSource,20}]\t[{Level,10}]\t{Message}";
        }
    }
}
