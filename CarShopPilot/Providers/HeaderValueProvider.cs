using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ValueProviders;

namespace CarShopPilot.Providers
{
    public class HeaderValueProvider : IValueProvider
    {
        private readonly HttpRequestMessage _requestMessage;

        public HeaderValueProvider(HttpRequestMessage requestMessage)
        {
            _requestMessage = requestMessage;
        }

        public bool ContainsPrefix(string prefix)
        {
            return _requestMessage.Headers.Contains(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            IEnumerable<string> headerValue;
            ValueProviderResult result = null;
            if (_requestMessage.Headers.TryGetValues(key, out headerValue))
            {
                var header = headerValue as IList<string> ?? headerValue.ToList();
                if (header.Any())
                {
                    var value = header.First();
                    result = new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
                }
            }
            return result;

        }
    }
}