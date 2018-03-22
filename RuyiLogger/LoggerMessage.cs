using System;
using System.Text;

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
        public LogLevel level;       // the log level
        public MessageCategory category;    // the message category
        protected string source;               // where the message comes from
        protected string channel;              // target service or topic, according to the eventType
        public string message;
        public DateTime Date { get; set; }

        public LoggerMessage()
        {
            Date = DateTime.Now;
            level = LogLevel.Debug;
        }

        public string ShownMessage
        {
            get
            {
                if (category == MessageCategory.Publisher || category == MessageCategory.Request || category == MessageCategory.Reply)
                {
                    byte[] bts = Convert.FromBase64String(message);
                    return Encoding.UTF8.GetString(bts);
                }
                return message;
            }
            set { }
        }

        public string MsgSource
        {
            get { return source; }
            set { source = value; }
        }

        public string MsgTarget
        {
            get { return channel; }
            set { channel = value; }
        }

        public string Topic
        {
            get { return channel; }
            set { channel = value; }
        }

        public string Message
        {
            get { return message; }
        }

        public string Category
        {
            get { return category.ToString(); }
        }

        public string Level
        {
            get { return level.ToString(); }
        }

        override public string ToString()
        {
            return $"[{category,10}]\t[{source,10}]\t[{channel,10}]\t{message}";
        }

        public string ToPluginString()
        {
            return $"[{Date,10}]\t[{source,20}]\t[{Level,10}]\t{message}";
        }
    }
}
