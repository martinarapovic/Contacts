using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http.ExceptionHandling;
using System.Web;

namespace Contacts.Common.ErrorHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new ErrorHttpActionResult(context.Request,
                                                           (HttpStatusCode) httpException.GetHttpCode(),
                                                           httpException.Message);
                return;
            }

            if (exception is RootObjectNotFoundException)
            {
                context.Result = new ErrorHttpActionResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }

            if (exception is ChildObjectNotFoundException)
            {
                context.Result = new ErrorHttpActionResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }

            if (exception is BusinessRuleViolationException)
            {
                context.Result = new ErrorHttpActionResult(context.Request, HttpStatusCode.Forbidden,
                                                           exception.Message);
                return;
            }

            context.Result = new ErrorHttpActionResult(context.Request, HttpStatusCode.InternalServerError,
                                                       exception.Message);
        }
    }
}