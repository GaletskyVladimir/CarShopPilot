using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace CarShopPilot.Errors
{
    public class ErrorMessage
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }

        public HttpResponseMessage GetError()
        {
            var message = new HttpResponseMessage(this.Code);

            var error = new
            {
                Code = this.Code.ToString(),
                Message = this.Message
            };

            message.Content = JsonContent.Create(new { Error = error });
            return message;
        }
    }
}