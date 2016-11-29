using System;
using System.Collections.Generic;
using ProductsEStore.LogHandler.LogSettingsHandler;
using ProductsEStore.LogHandler.Htmllog;
using ProductsEStore.LogHandler.XmlLog;

namespace ProductsEStore.LogHandler
{
    public static class LogManager
    {
        static List<ILogger> loggers = null;

        static LogManager()
        {
            loggers = new List<ILogger>();
        }

        public static void Write(string msg, Category cat = Category.Information)
        {
            if (LogSettings.Enable)
            {
                LogEntry logEntry = new LogEntry() { Message = msg, TimeStamp = DateTime.Now, Category = cat, Sno = LogSettings.SnoCounter++ };
                loggers.ForEach(logger => logger.Write(logEntry));
            }
        }

        internal static void Initalize()
        {
            foreach (Listener lis in LogSettings.Listeners)
            {
                switch (lis.ListenerType)
                {
                    case ListenerType.html:
                        loggers.Add(new HtmlLogger());
                        break;
                    case ListenerType.xml:
                        loggers.Add(new XmlLogger());
                        break;
                }
            }

            foreach (var logger in loggers)
            {
                logger.Init();
            }
        }
    }
}
