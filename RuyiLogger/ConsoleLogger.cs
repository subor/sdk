using System;

namespace RuyiLogger
{
    public class ConsoleLogger : IRuyiLogger
    {
        string silent = "silent";
        string verbose = "verbose";

        string logLevelStr = null;
        LogLevel logLevel = LogLevel.Debug;

        public void Log(LoggerMessage msg)
        {
            if (!FilterLog(msg))
                return;

            Console.WriteLine(msg.ToPluginString());
        }

        bool FilterLog(LoggerMessage msg)
        {
            if (logLevelStr == null || logLevelStr == verbose)
                return true;
            else if (logLevelStr == silent)
                return false;

            return (int)msg.Level >= (int)logLevel;
        }

        public void SetLogLevel(string lvl)
        {
            logLevelStr = lvl;
            if (lvl != null)
                logLevelStr = lvl.ToLower();
            if (lvl != null && logLevelStr != silent && logLevelStr != verbose)
            {
                logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), lvl);
            }
        }

        public void SetLogLevel(LogLevel lv)
        {
        }
    }
}
