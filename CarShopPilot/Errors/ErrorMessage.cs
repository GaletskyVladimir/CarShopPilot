using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CarShopPilot.Errors
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {

        }

        public ErrorMessage(HttpStatusCode code, string message, ModelStateDictionary modelState)
        {
            this.Code = code;
            this.Message = message;
            this.ModelState = modelState;
        }

        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }

        public ModelStateDictionary ModelState { get; set; }

        public HttpResponseMessage GetError()
        {
            var message = new HttpResponseMessage(this.Code);

            if (this.ModelState != null)
            {
                message.Content = JsonContent.Create(new
                {
                    Error = new
                    {
                        Code = this.Code.ToString(),
                        Message = this.Message,
                        ValidationDetails = this.ModelState
                    }
                });
            }
            else
            {
                message.Content = JsonContent.Create(new 
                { 
                    Error = new
                    {
                        Code = this.Code.ToString(),
                        Message = this.Message
                    }
                });
            }

            return message;
        }
    }
}