using CarShopPilot.Errors;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CarShopPilot.Filters
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<LogExceptionFilterAttribute> logger;

        public LogExceptionFilterAttribute(Logger<LogExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            logger.LogError("Exception was handled in Exception filter.", actionExecutedContext.Exception);
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }

            var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.InternalServerError, ErrorCode = ErrorCode.UnHandled, Message = $"An unhandled exception was thrown by service. {exceptionMessage}" };
            actionExecutedContext.Response = errorMessage.GetError();
        }
    }
}