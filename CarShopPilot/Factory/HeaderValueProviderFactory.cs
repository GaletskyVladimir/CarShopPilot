using CarShopPilot.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace CarShopPilot.Factory
{
    public class HeaderValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return new HeaderValueProvider(actionContext.Request);
        }
    }
}