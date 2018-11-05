using System;

namespace Ruyi.Logging
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
        MainClient,
        /// <summary>
        /// System tray application
        /// </summary>
        SystemTray,
        MiniUI = SystemTray,
        /// <summary>
        /// DevTool
        /// </summary>
        DevTool,

        RuyiNet,
        Overlay,
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

        public LoggerStackFrame[] Frames { get; set; }

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
            return $"[{Category,12}]\t[{MsgSource,25}]\t[{MsgTarget,10}]\t{Message}";
        }

        public string ToPluginString()
        {
            return $"[{Date,10}]\t[{MsgSource,20}]\t[{Level,10}]\t{Message}";
        }
    }

    public class LoggerMessageEx : LoggerMessage
    {
        /// <summary>
        /// Original exception
        /// </summary>
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// LoggerMessage refering to a path (either a file or folder)
    /// </summary>
    public class LogPathReferenceMessage : LoggerMessageEx
    {
        public string Path { get; private set; }
        public LogPathReferenceMessage(string path)
            : base()
        {
            Path = path;
        }
    }

    /// <summary>
    /// LoggerMessage refering to a specific file, and optionally line and column within the file.
    /// </summary>
    public class LogFileReferenceMessage : LoggerMessageEx
    {
        public string Path { get; private set; }
        public int Line { get; private set; }
        public int Col { get; private set; }

        public LogFileReferenceMessage(string path, int line = -1, int col = -1)
        {
            Path = path;
            Line = line;
            Col = col;
        }
    }

    public class LogCommandLineMessage : LoggerMessageEx
    {
        public string Command { get; set; }
        public string Arguments { get; set; }
    }

    /// <summary>
    /// Stack frame suitable for logging.
    /// </summary>
    /// <seealso cref="Logging.Logger"/>
    public class LoggerStackFrame
    {
        public string Filename { get; private set; }
        public string Method { get; private set; }
        public int Line { get; private set; }

        public LoggerStackFrame(System.Diagnostics.StackFrame frame)
        {
            Filename = frame.GetFileName();
            Method = frame.GetMethod().Name;
            Line = frame.GetFileLineNumber();
        }
    }
}
