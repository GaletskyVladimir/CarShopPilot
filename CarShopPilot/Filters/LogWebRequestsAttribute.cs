using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Workshop.Logging;

namespace CarShopPilot.Filters
{
    public class LogWebRequestsAttribute : ActionFilterAttribute
    {
        private const string REQUEST_START_TIME_KEY = "RequestStartTime";

        public override void OnActionExecuting(HttpActionContext context)
        {
            base.OnActionExecuting(context);

            context.Request.Properties[REQUEST_START_TIME_KEY] = DateTime.UtcNow;
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            TryLogWebRequestDuration(context);
        }

        private static void TryLogWebRequestDuration(HttpActionExecutedContext context)
        {
            try
            {
                var startedOn = (DateTime)context.Request.Properties[REQUEST_START_TIME_KEY];
                var endedOn = DateTime.UtcNow;
                var duration = (endedOn - startedOn).TotalSeconds;

                var controller = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
                var action = context.ActionContext.ActionDescriptor.ActionName;
                WebRequestLogger.LogRequest(controller, action, (int)duration);
            }
            catch (Exception ex)
            {
                //Log
            }
        }
    }
}