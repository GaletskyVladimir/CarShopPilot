using ApplicationServices.Containers;
using ApplicationServices.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public Vehicle AddVehicle(Vehicle vehicle)
        {
            return VehicleContainer.AddVehicle(vehicle);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return VehicleContainer.GetAll();
        }

        public Vehicle GetById(int vehicleId)
        {
            return VehicleContainer.GetById(vehicleId);
        }

        public IEnumerable<Vehicle> GetStoreVehicles(int storeId)
        {
            return VehicleContainer.GetStoreVehicles(storeId);
        }

        public Vehicle ModifyVehicle(Vehicle vehicle)
        {
            return VehicleContainer.UpdateVehicle(vehicle);
        }

        public void RemoveVehicle(int vehicleId)
        {
            VehicleContainer.RemoveVehicle(vehicleId);
        }
    }
}
