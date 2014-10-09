using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Contacts.Common.Logging
{
    public class MyExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public MyExceptionLogger(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof (MyExceptionLogger));
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error("Unhandled exception", context.Exception);
        }
    }
}