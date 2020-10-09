using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace CarShopPilot.Filters
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;
            //todo log ex
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            context.Response.StatusCode = HttpStatusCode.InternalServerError;
            context.Response.ReasonPhrase = "The request was invalid for the server";
        }
    }
}