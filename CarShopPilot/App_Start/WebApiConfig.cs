using CarShopPilot.Filters;
using CarShopPilot.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarShopPilot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Bootstrapper.Run();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new LogExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
