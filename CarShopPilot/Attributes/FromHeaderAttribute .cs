using CarShopPilot.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace CarShopPilot.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromHeaderAttribute : ModelBinderAttribute
    {
        public override IEnumerable<ValueProviderFactory> GetValueProviderFactories(HttpConfiguration configuration)
        {
            return base.GetValueProviderFactories(configuration).OfType<HeaderValueProviderFactory>();
        }
    }
}