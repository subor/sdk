using log4net;
using log4net.Core;
using log4net.Layout;
using System;
using System.Xml;

[assembly: log4net.Config.Repository("Layer0")]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace RuyiLogger
{
    public class Log4NetLogger : IRuyiLogger
    {
        private log4net.Repository.Hierarchy.Hierarchy repo = null;      // repo of our logger

        private LogLevel logLevel = LogLevel.Info;

        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Log4NetLogger()
        {
            repo = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository("Layer0"));
        }

        public void SetLogLevel(LogLevel lv)
        {
            if (logLevel == lv)
                return;

            logLevel = lv;
            switch (lv)
            {
                case LogLevel.Debug: repo.Root.Level = Level.Debug; break;
                case LogLevel.Info: repo.Root.Level = Level.Info; break;
                case LogLevel.Warn: repo.Root.Level = Level.Warn; break;
                case LogLevel.Error: repo.Root.Level = Level.Error; break;
                case LogLevel.Fatal: repo.Root.Level = Level.Fatal; break;
                default:
                    // OOPS
                    break;
            }
            
            repo.RaiseConfigurationChanged(EventArgs.Empty);
        }

        public void Log(LoggerMessage msg)
        {
            switch (msg.Level)
            {
                case LogLevel.Debug: logger.Debug(msg); break;
                case LogLevel.Info: logger.Info(msg); break;
                case LogLevel.Warn: logger.Warn(msg); break;
                case LogLevel.Error: logger.Error(msg); break;
                case LogLevel.Fatal: logger.Fatal(msg); break;
                default:
                    // OOPS
                    break;
            }
        }
    }

    public class DevLogXmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            LoggerMessage msg = loggingEvent.MessageObject as LoggerMessage;
            writer.WriteStartElement("LogEntry");

            writer.WriteStartElement("Date");
            writer.WriteString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff"));
            writer.WriteEndElement();

            writer.WriteStartElement("Level");
            writer.WriteString(msg.Level.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Category");
            writer.WriteString(msg.Category.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Source");
            writer.WriteString(msg.MsgSource);
            writer.WriteEndElement();

            writer.WriteStartElement("Channel");
            writer.WriteString(msg.Topic);
            writer.WriteEndElement();

            writer.WriteStartElement("Message");
            writer.WriteString(msg.Message);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
