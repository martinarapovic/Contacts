using log4net;
using System;

namespace Contacts.Common.Logging
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLoggerName)
        {
            return LogManager.GetLogger(typeAssociatedWithRequestedLoggerName);
        }
    }
}