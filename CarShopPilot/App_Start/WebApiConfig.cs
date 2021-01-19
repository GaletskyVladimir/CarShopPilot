using CarShopPilot.Factory;
using CarShopPilot.Filters;
using CarShopPilot.Util;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace CarShopPilot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Bootstrapper.Run();
            config.Services.Add(typeof(ValueProviderFactory), new HeaderValueProviderFactory());
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new LogExceptionFilterAttribute(new Logger<LogExceptionFilterAttribute>()));
            config.Filters.Add(new LogWebRequestsAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
