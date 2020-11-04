using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Models;
using ApplicationServices.Services;
using CarShopPilot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                return BadRequest($"User with id {userId} does not exists");
            }
        }

		[HttpPost, Route("")]
		public IHttpActionResult CreateUser([FromBody]UserSummary userSummary)
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!storeService.DoesStoreExists(userSummary.StoreID))
            {
                return BadRequest($"Store with id {userSummary.StoreID} does not exists");
            }
            return Ok(userService.CreateUser(userSummary));
		}

        [HttpPut, Route("{userId}")]
        public IHttpActionResult UpdateUser([FromUri] int userId, [FromBody] UserSummary userSummary)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!storeService.DoesStoreExists(userSummary.StoreID))
                {
                    return BadRequest($"Store with id {userSummary.StoreID} does not exists");
                }
                return Ok(userService.EditUser(userSummary, userId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"User with id {userId} does not exists");
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
                return BadRequest($"User with id {userId} does not exists");
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
                return BadRequest($"User with id {userId} does not exists");
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
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }
    }
}
