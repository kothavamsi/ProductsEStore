using ProductsEStore.LogHandler.LogSettingsHandler;

namespace ProductsEStore.LogHandler.XmlLog
{
    public class XmlLogger : ILogger
    {
        public XmlLogger()
        {

        }

        public void Init()
        {
            if (LogSettings.Enable)
            {
            }
        }

        public void Write(LogEntry logEntry)
        {

        }
    }
}
