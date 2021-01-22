using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public interface ILogger<T>
    {
        void LogTrace(string message);

        void LogDebug(string message);

        void LogDebug(string message, params object[] parameters);

        void LogInfo(string message);

        void LogInfo(string message, params object[] parameters)

        void LogWarning(string message);

        void LogWarning(string message, params object[] parameters);

        void LogError(string message, Exception exception);

        void LogFatal(string message);
    }
}
