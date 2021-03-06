﻿using System;
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

        public ErrorMessage(HttpStatusCode httpCode, ErrorCode errorCode, string message, ModelStateDictionary modelState)
        {
            this.HttpCode = httpCode;
            this.Message = message;
            this.ModelState = modelState;
            this.ErrorCode = errorCode;
        }

        public HttpStatusCode HttpCode { get; set; }

        public ErrorCode ErrorCode { get; set; }

        public string Message { get; set; }

        public ModelStateDictionary ModelState { get; set; }

        public string GetStateErrors()
        {
            var finalString = string.Empty;

            foreach(var state in this.ModelState.Values)
            {
                if (state.Errors.Count == 1)
                {
                    finalString += state.Errors.First().ErrorMessage + " ";
                }
            }

            return finalString;
        }

        public HttpResponseMessage GetError()
        {
            var message = new HttpResponseMessage(this.HttpCode);

            if (this.ModelState != null)
            {
                message.Content = JsonContent.Create(new
                {
                    Error = new
                    {
                        Code = this.ErrorCode.ToString(),
                        Message = this.Message,
                        //ValidationDetails = this.ModelState.Values.ToList() smth wrong with model state
                    }
                });
            }
            else
            {
                message.Content = JsonContent.Create(new 
                { 
                    Error = new
                    {
                        Code = this.ErrorCode.ToString(),
                        Message = this.Message
                    }
                });
            }

            return message;
        }
    }
}