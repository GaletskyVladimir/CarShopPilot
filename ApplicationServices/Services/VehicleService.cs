using ApplicationServices.Interfaces;
using ApplicationServices.IServices;
using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return vehicleRepository.GetAll();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return vehicleRepository.GetById(vehicleId);
        }

        public Vehicle CreateVehicle(VehicleSummary vehicleSummary)
        {
            //todo mapper
            var vehicle = new Vehicle
            {
                StoreID = vehicleSummary.StoreID,
                Make = vehicleSummary.Make,
                Model = vehicleSummary.Model,
                Price = vehicleSummary.Price,
                Year = vehicleSummary.Year
            };
            return vehicleRepository.AddVehicle(vehicle);
        }

        public Vehicle EditVehicle(VehicleSummary vehicleSummary, int vehicleId)
        {
            var vehicle = vehicleRepository.GetById(vehicleId);
            vehicle.StoreID = vehicleSummary.StoreID;
            vehicle.Make = vehicleSummary.Make;
            vehicle.Model = vehicleSummary.Model;
            vehicle.Price = vehicleSummary.Price;
            vehicle.Year = vehicleSummary.Year;
            return vehicleRepository.ModifyVehicle(vehicle);
        }

        public IEnumerable<Vehicle> GetStoreVehicles(int storeId)
        {
            return vehicleRepository.GetStoreVehicles(storeId);
        }

        public void RemoveVehicle(int vehicleId)
        {
            vehicleRepository.RemoveVehicle(vehicleId);
        }
    }
}
