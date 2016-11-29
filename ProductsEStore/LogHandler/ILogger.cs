using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsEStore.LogHandler
{
    interface ILogger
    {
        void Init();
        void Write(LogEntry logEntry);
    }
}
