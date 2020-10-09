using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Logging
{
    public static class WebRequestLogger
    {
        private static List<string> logs { get; set; }

        static WebRequestLogger()
        {
            logs = new List<string>();
        }

        public static void LogRequest(string controllerName, string actionName, int duration)
        {
            if (logs.Count > 10)
            {
                logs.Clear();
            }
            logs.Add($"{controllerName} - {actionName} : {duration}");
        }
    }
}
