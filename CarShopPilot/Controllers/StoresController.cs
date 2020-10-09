using ApplicationServices.Interfaces;
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
    [RoutePrefix("api/stores")]
    public class StoresController : ApiController
    {
        private readonly StoreService storeService;

        public StoresController(IStoreRepository storeRepository)
        {
            storeService = new StoreService(storeRepository);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetStores()
        {
            return Ok(storeService.GetAllStores());
        }

        [HttpGet, Route("{storeId}")]
        public IHttpActionResult GetStoreById(int storeId)
        {
            try
            {
                return Ok(storeService.GetStoreById(storeId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult CreateStore([FromBody] StoreSummary storeSummary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(storeService.CreateStore(storeSummary));
        }

        [HttpPut, Route("{storeId}")]
        public IHttpActionResult UpdateStore([FromUri] int storeId, [FromBody] StoreSummary storeSummary)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(storeService.EditStore(storeSummary, storeId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }

        [HttpDelete, Route("{storeId}")]
        public IHttpActionResult DeleteStore(int storeId)
        {
            try
            {
                storeService.RemoveStore(storeId);
                return Ok("Successfully removed");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }
    }
}
