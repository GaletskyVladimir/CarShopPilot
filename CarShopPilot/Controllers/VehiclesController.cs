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
    [RoutePrefix("api/vehicles")]
    public class VehiclesController : ApiController
    {
        private readonly IVehicleService vehicleService;

        private readonly IStoreRepository storeRepository;

        public VehiclesController(IVehicleService vehicleService, IStoreRepository storeRepository)
        {
            this.vehicleService = vehicleService;
            this.storeRepository = storeRepository;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetVehicles()
        {
            return Ok(vehicleService.GetAllVehicles());
        }

        [HttpGet, Route("{vehicleId}")]
        public IHttpActionResult GetVehicleById(int vehicleId)
        {
            try
            {
                return Ok(vehicleService.GetVehicleById(vehicleId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Vehicle with id {vehicleId} does not exists");
            }
        }

        [HttpPost, Route("")]
        public IHttpActionResult CreateVehicle([FromBody] VehicleSummary vehicleSummary)
        {
            if (vehicleSummary.Year < 1900)
                ModelState.AddModelError("vehicleSummary.Year", "Invalid Vehicle Year");
            if (vehicleSummary.Price <= 0)
                ModelState.AddModelError("vehicleSummary.Price", "Price must be positive value");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!storeRepository.DoesStoreExists(vehicleSummary.StoreID))
            {
                return BadRequest($"Store with id {vehicleSummary.StoreID} does not exists");
            }
            return Ok(vehicleService.CreateVehicle(vehicleSummary));
        }

        [HttpPut, Route("{vehicleId}")]
        public IHttpActionResult UpdateVehicle([FromUri] int vehicleId, [FromBody] VehicleSummary vehicleSummary)
        {
            try
            {
                if (vehicleSummary.Year < 1900)
                    ModelState.AddModelError("vehicleSummary.Year", "Invalid Vehicle Year");
                if (vehicleSummary.Price <= 0)
                    ModelState.AddModelError("vehicleSummary.Price", "Price must be positive value");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!storeRepository.DoesStoreExists(vehicleSummary.StoreID))
                {
                    return BadRequest($"Store with id {vehicleSummary.StoreID} does not exists");
                }
                return Ok(vehicleService.EditVehicle(vehicleSummary, vehicleId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Vehicle with id {vehicleId} does not exists");
            }
        }

        [HttpDelete, Route("{vehicleId}")]
        public IHttpActionResult DeleteVehicle(int vehicleId)
        {
            try
            {
                vehicleService.RemoveVehicle(vehicleId);
                return Ok("Successfully removed");
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Vehicle with id {vehicleId} does not exists");
            }
        }

        [HttpGet, Route("{storeId}/storevehicles")]
        public IHttpActionResult GetVehiclesByStoreId(int storeId)
        {
            try
            {
                return Ok(vehicleService.GetStoreVehicles(storeId));
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Store with id {storeId} does not exists");
            }
        }
    }
}
