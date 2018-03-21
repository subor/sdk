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
            for (int i = 0; i < ruyiLoggers.Count; i++)
                ruyiLoggers[i].Log(msg);
        }

    }
}
