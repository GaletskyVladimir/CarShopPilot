using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Models;
using ApplicationServices.Services;
using CarShopPilot.Attributes;
using CarShopPilot.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Http;

namespace CarShopPilot.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        private readonly IStoreService storeService;

        public UsersController(IUserService userService, IStoreService storeService)
        {
            this.userService = userService;
            this.storeService = storeService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetUsers([FromHeader(Name = "TestId")] int testId) 
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet, Route("{userId}")]
        public IHttpActionResult GetUserById(int userId)
        {
            try
            {
                return Ok(userService.GetUserById(userId));
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"User with id {userId} not found" };
                return ResponseMessage(errorMessage.GetError());
            }
        }

		[HttpPost, Route("")]
		public IHttpActionResult CreateUser([FromBody]UserSummary userSummary)
		{
            if (!ModelState.IsValid)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            if (!storeService.DoesStoreExists(userSummary.StoreID))
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"Store with id {userSummary.StoreID} does not exists" };
                return ResponseMessage(errorMessage.GetError());
            }
            return Ok(userService.CreateUser(userSummary));
		}

        [HttpPut, Route("{userId}")]
        public IHttpActionResult UpdateUser([FromUri] int userId, [FromBody] UserSummary userSummary)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
                if (!storeService.DoesStoreExists(userSummary.StoreID))
                {
                    var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"Store with id {userSummary.StoreID} does not exists" };
                    return ResponseMessage(errorMessage.GetError());
                }
                return Ok(userService.EditUser(userSummary, userId));
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"User with id {userId} not found" };
                return ResponseMessage(errorMessage.GetError());
            }
        }

        [HttpDelete, Route("{userId}")]
        public IHttpActionResult DeleteUser(int userId)
        {
            try
            {
                userService.RemoveUser(userId);
                return Ok("Successfully removed");
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"User with id {userId} not found" };
                return ResponseMessage(errorMessage.GetError());
            }
        }

        [HttpPatch, Route("{userId}/activity/{isActive}")]
        public IHttpActionResult ChangeUserActivityStatus(int userId, bool isActive)
        {
            try
            {
                return Ok(userService.UpdateUserActivity(userId, isActive));
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"User with id {userId} not found" };
                return ResponseMessage(errorMessage.GetError());
            }
        }

        [HttpGet, Route("{storeId}/storeusers")]
        public IHttpActionResult GetUsersByStoreId(int storeId)
        {
            try
            {
                return Ok(userService.GetStoreUsers(storeId));
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { Code = HttpStatusCode.NotFound, Message = $"Store with id {storeId} does not exists" };
                return ResponseMessage(errorMessage.GetError());
            }
        }
    }
}
