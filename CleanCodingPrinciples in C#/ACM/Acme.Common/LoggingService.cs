using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class LoggingService
    {
        public static StringBuilder WriteToFile(List<ILoggable> itemsToLog)
        {
            StringBuilder sb = new StringBuilder();
            itemsToLog.ForEach(item => sb.AppendLine(item.Log()));
            return sb;
        }
    }
}
