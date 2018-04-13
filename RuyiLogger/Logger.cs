using System.Collections.Generic;

namespace RuyiLogger
{
    public interface IRuyiLogger
    {
        void Log(LoggerMessage msg);

        void SetLogLevel(LogLevel lv);
    }

    static public class Logger
    {
        private static LogLevel logLevel = LogLevel.Info;

        private static List<IRuyiLogger> ruyiLoggers = new List<IRuyiLogger>();

        static Logger()
        {
            Log4NetLogger log4Net = new Log4NetLogger();
            ruyiLoggers.Add(log4Net);
        }

        static public void AddRuyiLogger(IRuyiLogger logger)
        {
            if (logger == null)
                return;

            if (!ruyiLoggers.Contains(logger))
                ruyiLoggers.Add(logger);
        }

        static public void RemoveRuyiLogger(IRuyiLogger logger)
        {
            if (logger == null)
                return;

            if (ruyiLoggers.Contains(logger))
                ruyiLoggers.Remove(logger);
        }

        static public void ClearAllLoggers()
        {
            ruyiLoggers.Clear();
        }

        static public void SetLogLevel(LogLevel lv)
        {
            if (logLevel == lv)
                return;

            logLevel = lv;
            for (int i = 0; i < ruyiLoggers.Count; i++)
                ruyiLoggers[i].SetLogLevel(lv);
        }

        static public void Log(LoggerMessage msg)
        {
            if (msg.Level >= LogLevel.Warn && msg.Frames == null)
            {
                msg.Frames = GetFrames(5).ToArray();
            }

            for (int i = 0; i < ruyiLoggers.Count; i++)
                ruyiLoggers[i].Log(msg);
        }

        static public void Log(string message, LogLevel level = LogLevel.Debug, MessageCategory category = MessageCategory.Unknown, string source = null, string topic = null)
        {
            Log(new LoggerMessage
            {
                Level = level,
                Category = category,
                MsgSource = source,
                Topic = topic,
                Message = message,
            });
        }

        /// <summary>
        /// Get stack frames suitable for logging
        /// </summary>
        /// <param name="maxFrames"></param>
        /// <returns></returns>
        static public List<LoggerStackFrame> GetFrames(int maxFrames)
        {
            var stackTrace = new System.Diagnostics.StackTrace(true);
            var list = new List<LoggerStackFrame>();

            for (int i = 0; i < stackTrace.FrameCount; ++i)
            {
                var frame = stackTrace.GetFrame(i);
                if (frame.GetFileName() == null)
                    continue;
                list.Add(new LoggerStackFrame(frame));

                // If we've got several frames just stop.  We don't need full callstack
                if (list.Count >= maxFrames)
                    break;
            }
            return list;
        }
    }
}
