using ApplicationServices.Interfaces;
using ApplicationServices.Models;
using ApplicationServices.Services;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarShopPilot.Controllers
{
    [RoutePrefix("api/deals")]
    public class DealsController : ApiController
    {
        private readonly CustomerService customerService;

        private readonly StoreService storeService;

        private readonly UserService userSerivce;

        private readonly DealService dealService;

        public DealsController(IDealRepository dealRepo, ICustomerRepository customerRepo, IStoreRepository storeRepository, IUserRepository userRepository)
        {
            this.dealService = new DealService(dealRepo);
            this.customerService = new CustomerService(customerRepo);
            this.storeService = new StoreService(storeRepository);
            this.userSerivce = new UserService(userRepository);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetDeals()
        {
            return Ok(dealService.GetAllDeals());
        }

        [HttpGet, Route("active")]
        public IHttpActionResult GetActiveDeals()
        {
            return Ok(dealService.GetAllActiveDeals());
        }

        [HttpGet, Route("{dealId}")]
        public IHttpActionResult GetDealById(int dealId)
        {
            try
            {
                return Ok(dealService.GetDealById(dealId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Deal with id {dealId} does not exists");
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult CreateDeal([FromBody] DealSummary dealSummary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!userSerivce.DoesUserExists(dealSummary.UserId))
            {
                return BadRequest($"Store with id {dealSummary.UserId} does not exists");
            }
            return Ok(dealService.AddDeal(dealSummary));
        }

        [HttpDelete, Route("{dealId}")]
        public IHttpActionResult DeleteDeal(int dealId)
        {
            try
            {
                dealService.RemoveDeal(dealId);
                return Ok("Successfully removed");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Deal with id {dealId} does not exists");
            }
        }

        [HttpPatch, Route("{dealId}/user/{userId}")]
        public IHttpActionResult ChangeUser(int dealId, int userId)
        {
            try
            {
                return Ok(dealService.ChangeUser(dealId, userId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Deal with id {dealId} does not exists");
            }
        }

        [HttpPatch, Route("{dealId}/status/{dealStatus}")]
        public IHttpActionResult UpdateDealStatus(int dealId, int dealStatus)
        {
            try
            {
                if (dealStatus <= 0 || dealStatus > 4)
                {
                    return BadRequest($"Deal status incorrect");
                }
                DealStatus status = (DealStatus)dealStatus;
                return Ok(dealService.UpdateDealStatus(dealId, status));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Deal with id {dealId} does not exists");
            }
        }

        [HttpPatch, Route("{dealId}/delivery")]
        public IHttpActionResult DeliveryDeal([FromUri] int dealId)
        {
            try
            {
                return Ok(dealService.DeliveryDeal(dealId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Deal with id {dealId} does not exists");
            }
        }
    }
}
