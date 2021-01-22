using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class Logger<T> : ILogger<T>
    {
        private NLog.ILogger logger;

        public Logger()
        {
            logger = NLog.LogManager.GetLogger(typeof(T).FullName);
        }

        public void LogTrace(string message)
        {
            throw new NotImplementedException();
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        
        public void LogDebug(string message, params object[] parameters)
        {
            logger.Debug(message, parameters);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogInfo(string message, params object[] parameters)
        {
            logger.Info(message, parameters);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }

        public void LogWarning(string message, params object[] parameters)
        {
            logger.Warn(message, parameters);
        }

        public void LogError(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public void LogFatal(string message)
        {
            logger.Fatal(message);
        }
    }
}
