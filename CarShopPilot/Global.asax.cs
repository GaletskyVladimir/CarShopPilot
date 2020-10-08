using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarShopPilot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            //todo log ex
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;
            Response.Write(JsonConvert.SerializeObject(new { Message = "The request was invalid for the server" }));
            Response.End();
        }
    }
}
