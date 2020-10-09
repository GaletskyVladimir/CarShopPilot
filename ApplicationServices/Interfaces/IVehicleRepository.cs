using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();

        Vehicle GetById(int vehicleId);

        Vehicle AddVehicle(Vehicle vehicle);

        Vehicle ModifyVehicle(Vehicle vehicle);

        void RemoveVehicle(int vehicleId);

        IEnumerable<Vehicle> GetStoreVehicles(int storeId);
    }
}
