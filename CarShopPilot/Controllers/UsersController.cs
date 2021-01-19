using ApplicationServices.IServices;
using ApplicationServices.Models;
using CarShopPilot.Attributes;
using CarShopPilot.Errors;
using Common.Logging;
using System;
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

        private readonly ILogger<UsersController> logger;

        public UsersController(IUserService userService, IStoreService storeService, ILogger<UsersController> logger)
        {
            this.userService = userService;
            this.storeService = storeService;
            this.logger = logger;
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
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.UserNotFound, Message = $"User with id {userId} not found" };
                return ResponseMessage(errorMessage.GetError());
            }
        }

		[HttpPost, Route("")]
		public IHttpActionResult CreateUser([FromBody]UserSummary userSummary)
		{
            if (!ModelState.IsValid)
            {
                var errorMessage = new ErrorMessage(HttpStatusCode.BadRequest, ErrorCode.BadArgument, "Errors in User data", ModelState);
                return ResponseMessage(errorMessage.GetError());
            }    
            if (!storeService.DoesStoreExists(userSummary.StoreID))
            {
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.StoreNotFound, Message = $"Store with id {userSummary.StoreID} does not exists" };
                return ResponseMessage(errorMessage.GetError());
            }
            return Ok(userService.CreateUser(userSummary));
		}

        [HttpPut, Route("{userId}")]
        public IHttpActionResult UpdateUser([FromUri] int userId, [FromBody] UserSummary userSummary)
        {
            try
            {
                logger.LogDebug($"User Data Update for user with ID: {userId}");
                if (!ModelState.IsValid)
                {
                    //throw new ArgumentException("5");
                    var errorMessage = new ErrorMessage(HttpStatusCode.BadRequest, ErrorCode.BadArgument, "Errors in User data", ModelState);
                    logger.LogWarning($"User with id `{userId}` was not updated. Reason: invalid User data.");
                    return ResponseMessage(errorMessage.GetError());
                }
                if (!storeService.DoesStoreExists(userSummary.StoreID))
                {
                    var errorMessage = new ErrorMessage() { ErrorCode = ErrorCode.StoreNotFound, Message = $"Store with id {userSummary.StoreID} does not exists" };
                    logger.LogWarning($"User data for user with id `{userId}` was not updated. Reason: invalid Store ID: `userSummary.StoreID`, does not exists");
                    return ResponseMessage(errorMessage.GetError());
                }
                else
                {
                    logger.LogInfo($"User with id `{userId}` was successfully updated");
                    return Ok(userService.EditUser(userSummary, userId));
                }
            }
            catch (InvalidOperationException)
            {
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.UserNotFound, Message = $"User with id {userId} not found" };
                logger.LogWarning($"User with id `{userId}` was not updated. Reason: user was not found in database.");
                return ResponseMessage(errorMessage.GetError());
            }
            catch (Exception ex)
            {
                logger.LogError($"Error happend during user update", ex);
                return InternalServerError();
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
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.UserNotFound, Message = $"User with id {userId} not found" };
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
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.UserNotFound, Message = $"User with id {userId} not found" };
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
                var errorMessage = new ErrorMessage() { HttpCode = HttpStatusCode.NotFound, ErrorCode = ErrorCode.UserNotFound, Message = $"Store with id {storeId} does not exists" };
                return ResponseMessage(errorMessage.GetError());
            }
        }
    }
}
