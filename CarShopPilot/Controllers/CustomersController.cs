using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Models;
using ApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarShopPilot.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        private readonly IStoreService storeService;

        private readonly IUserService userSerivce;

        public CustomersController(ICustomerService customerService, IStoreService storeService, IUserService userSerivce)
        {
            this.customerService = customerService;
            this.storeService = storeService;
            this.userSerivce = userSerivce;
        }

        //Count
        //PageCount
        //Pagination with Wrapper

        [HttpGet, Route("")]
        public IHttpActionResult GetCustomer()
        {
            return Ok(customerService.GetAllCustomers());
        }

        [HttpGet, Route("{customerId}")]
        public IHttpActionResult GetCustomerById(int customerId)
        {
            try
            {
                return Ok(customerService.GetCustomerById(customerId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Customer with id {customerId} does not exists");
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult CreateCustomer([FromBody] CustomerSummary customerSummary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!storeService.DoesStoreExists(customerSummary.StoreID))
            {
                return BadRequest($"Store with id {customerSummary.StoreID} does not exists");
            }
            if (!userSerivce.DoesUserExists(customerSummary.UserID))
            {
                return BadRequest($"User with id {customerSummary.UserID} does not exists");
            }
            return Ok(customerService.CreateCustomer(customerSummary));
        }

        [HttpPut, Route("{customerId}")]
        public IHttpActionResult UpdateCustomer([FromUri] int customerId, [FromBody] CustomerSummary customerSummary)
        {
            try
            {
                //Does customer belongs to the store
                //Is user valid
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!storeService.DoesStoreExists(customerSummary.StoreID))
                {
                    return BadRequest($"Store with id {customerSummary.StoreID} does not exists");
                }
                if (!userSerivce.DoesUserExists(customerSummary.UserID))
                {
                    return BadRequest($"User with id {customerSummary.UserID} does not exists");
                }
                return Ok(customerService.EditCustomer(customerSummary, customerId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Customer with id {customerId} does not exists");
            }
        }

        [HttpDelete, Route("{customerId}")]
        public IHttpActionResult DeleteCustomer(int customerId)
        {
            try
            {
                customerService.RemoveCustomer(customerId);
                return Ok("Successfully removed");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Customer with id {customerId} does not exists");
            }
        }

        [HttpGet, Route("{storeId}/storecustomers")]
        public IHttpActionResult GetCustomersByStoreId(int storeId)
        {
            try
            {
                return Ok(customerService.GetStoreCustomers(storeId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }

        [HttpGet, Route("{userId}/usercustomers")]
        public IHttpActionResult GetCustomersByUserId(int userId)
        {
            try
            {
                return Ok(customerService.GetUserCustomers(userId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {userId} does not exists");
            }
        }
    }
}
