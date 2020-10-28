using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.IServices
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetAllVehicles();

        Vehicle GetVehicleById(int vehicleId);

        Vehicle CreateVehicle(VehicleSummary vehicleSummary);

        Vehicle EditVehicle(VehicleSummary vehicleSummary, int vehicleId);

        IEnumerable<Vehicle> GetStoreVehicles(int storeId);

        void RemoveVehicle(int vehicleId);
    }
}
