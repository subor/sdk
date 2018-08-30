using System.Collections.Generic;

namespace Ruyi.Logging
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
#if DEBUG
            if (msg.Level >= LogLevel.Warn && msg.Frames == null)
            {
                msg.Frames = GetFrames(1, 5).ToArray();
            }
#endif

            for (int i = 0; i < ruyiLoggers.Count; i++)
                ruyiLoggers[i].Log(msg);
        }

        /// <summary>
        /// <see cref="Log(LoggerMessage)"/>
        /// </summary>
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
        /// Version of <see cref="Log(string, LogLevel, MessageCategory, string, string)"/> that only executes in DEBUG builds.  Will be ignored by compiler in non-debug builds.
        /// </summary>
        [System.Diagnostics.Conditional("DEBUG")]
        static public void Debug(string message, LogLevel level = LogLevel.Debug, MessageCategory category = MessageCategory.Unknown, string source = null, string topic = null)
        {
#if DEBUG
            Log(new LoggerMessage
            {
                Level = level,
                Category = category,
                MsgSource = source,
                Topic = topic,
                Message = message,
            });
#endif
        }

        /// <summary>
        /// Get stack frames suitable for logging
        /// </summary>
        /// <param name="maxFrames">Number of frames to return.  If less than or equal to 0, all frames.</param>
        /// <returns></returns>
        static public List<LoggerStackFrame> GetFrames(int skipFrames = 0, int maxFrames = 0)
        {
            var stackTrace = new System.Diagnostics.StackTrace(skipFrames, true);
            var retval = new List<LoggerStackFrame>();

            for (int i = 0; i < stackTrace.FrameCount; ++i)
            {
                var frame = stackTrace.GetFrame(i);
                if (frame.GetFileName() == null)
                    continue;
                retval.Add(new LoggerStackFrame(frame));

                if (maxFrames > 0 && retval.Count >= maxFrames)
                    break;
            }
            return retval;
        }
    }
}
