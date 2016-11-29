using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsEStore.LogHandler
{
    public enum Category
    {
        Information,
        Warning,
        Error,
        Critical
    }

    public class RequestInformation
    {
        public string UserAgent { get; set; }
        public string IpAddress { get; set; }
        public string RequestUrl { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] [{1}] [{2}]", RequestUrl,UserAgent, IpAddress );
        }
    }

    public class LogEntry
    {
        public int Sno { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public Category Category { get; set; }

        static LogEntry()
        {

        }
    }
}
