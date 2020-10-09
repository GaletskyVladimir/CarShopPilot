using ApplicationServices.Interfaces;
using ApplicationServices.Services;
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
        private readonly UserService userService;

        public UsersController(IUserRepository userRepository)
        {
            userService = new UserService(userRepository);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetUsers() 
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
		public IHttpActionResult CreateUser()
		{
            return null;
		}

        [HttpPut, Route("")]
        public IHttpActionResult UpdateUser()
        {
            return null;
        }

        [HttpDelete, Route("userId")]
        public IHttpActionResult DeleteUser()
        {
            return null;
        }
    }
}
