using Ruyi.Logging;

namespace Ruyi.Layer0
{
    static public class Layer0Logger
    {
        static public void Debug(string msg, string source = "layer0")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Debug;
            lm.MsgTarget = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Info(string msg, string source = "layer0")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Info;
            lm.MsgTarget = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Warn(string msg, string source = "layer0")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Warn;
            lm.MsgTarget = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Error(string msg, string source = "layer0")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Error;
            lm.MsgTarget = "";
            lm.Message = msg;

            Logger.Log(lm);
        }

        static public void Fatal(string msg, string source = "layer0")
        {
            LoggerMessage lm = new LoggerMessage();
            lm.Category = MessageCategory.Framework;
            lm.MsgSource = source;
            lm.Level = LogLevel.Fatal;
            lm.MsgTarget = "";
            lm.Message = msg;

            Logger.Log(lm);
        }
    }
}
