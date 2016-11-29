using System;
using System.IO;
using System.Linq;
using ProductsEStore.LogHandler.LogSettingsHandler;

namespace ProductsEStore.LogHandler.Htmllog
{
    class HtmlLogger : ILogger
    {
        private string SNO = "{{SNO}}";
        private string LOGENTRY_TIME_STAMP = "{{LOGENTRY_TIME_STAMP}}";
        private string CATEGORY = "{{CATEGORY}}";
        private string CATEGORY_CSS_CLASS = "{{CATEGORY_CSS_CLASS}}";
        private string MESSAGE = "{{MESSAGE}}";
        private string LOGFILE_CREATED_ON = "{{LOGFILE_CREATED_ON}}";

        private string TemplateLogEntry = "";
        private string TemplateLogFileContent = "";
        private string PopulatedLogEntry = "";
        private string PopulatedLogFileContent = "";

        private string HtmlListenerPath = "";

        public HtmlLogger()
        {

        }

        public void Init()
        {
            HtmlListenerPath = LogSettings.Listeners.Where(li => li.ListenerType == ListenerType.html).First().Path;
            var lines = File.ReadLines(@"F:\WorkSpace\VisualStudioDnetExamples\ProductsEStore\ProductsEStore\LogHandler\HtmlLog\HtmlTemplate.htm").ToList();

            var index = lines.FindIndex(li => li.Contains("<!DOCTYPE"));
            TemplateLogEntry = string.Join("", lines.Take(index));
            TemplateLogFileContent = string.Join("", lines.Skip(index));

            PopulatedLogFileContent = TemplateLogFileContent.Replace(LOGFILE_CREATED_ON, DateTime.Now.ToString());

            if (LogSettings.Overwrite == false)
            {
                HtmlListenerPath = Guid.NewGuid() + ".htm";
            }
            if (LogSettings.Enable)
            {
                File.WriteAllText(HtmlListenerPath, PopulatedLogFileContent);
            }
        }

        public void Write(LogEntry logEntry)
        {
            var tmpLogEntry = TemplateLogEntry;
            tmpLogEntry = tmpLogEntry.Replace(SNO, logEntry.Sno.ToString());
            tmpLogEntry = tmpLogEntry.Replace(LOGENTRY_TIME_STAMP, logEntry.TimeStamp.ToString());
            tmpLogEntry = tmpLogEntry.Replace(CATEGORY, logEntry.Category.ToString());
            tmpLogEntry = tmpLogEntry.Replace(CATEGORY_CSS_CLASS, logEntry.Category.ToString());
            PopulatedLogEntry = tmpLogEntry.Replace(MESSAGE, logEntry.Message.ToString());
            lock (this)
            {
                File.AppendAllText(HtmlListenerPath, PopulatedLogEntry);
            }
        }
    }
}
