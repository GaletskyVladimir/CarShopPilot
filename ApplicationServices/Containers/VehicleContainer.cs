using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Containers
{
    public static class VehicleContainer
    {
        private static int currentPrimaryId = 1;

        private static List<Vehicle> vehicles { get; set; }

        static VehicleContainer()
        {
            initVehicles();
        }

        //todo: optional pagination
        public static IEnumerable<Vehicle> GetAll() => vehicles;

        public static Vehicle GetById(int vehicleId)
        {
            return vehicles.First(x => x.ID == vehicleId);
        }

        public static Vehicle AddVehicle(Vehicle vehicle)
        {
            var savingVehicle = new Vehicle(currentPrimaryId)
            {
                StoreID = vehicle.StoreID,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Price = vehicle.Price,
                Year = vehicle.Year
            };

            vehicles.Add(savingVehicle);
            currentPrimaryId++;
            return savingVehicle;
        }

        public static Vehicle UpdateVehicle(Vehicle vehicle)
        {
            var updatingUser = vehicles.First(x => x.ID == vehicle.ID);

            updatingUser.StoreID = vehicle.StoreID;
            updatingUser.Make = vehicle.Make;
            updatingUser.Model = vehicle.Model;
            updatingUser.Price = vehicle.Price;
            updatingUser.Year = vehicle.Year;
            return updatingUser;
        }

        public static void RemoveVehicle(int vehicleId)
        {
            var removingVehicle = vehicles.First(x => x.ID == vehicleId);
            vehicles.Remove(removingVehicle);
        }

        public static IEnumerable<Vehicle> GetStoreVehicles(int storeId)
        {
            return vehicles.Where(x => x.StoreID == storeId);
        }

        private static void initVehicles()
        {
            vehicles = new List<Vehicle>();

            vehicles.AddRange(
                new List<Vehicle>()
                {
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 1,
                        Make = "Nissan",
                        Model = "S300",
                        Price = 8000,
                        Year = 2008
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 1,
                        Make = "Nissan",
                        Model = "S300",
                        Price = 8000,
                        Year = 2008
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 1,
                        Make = "Nissan",
                        Model = "S300",
                        Price = 8000,
                        Year = 2008
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 1,
                        Make = "Nissan",
                        Model = "S300",
                        Price = 8000,
                        Year = 2008
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 2,
                        Make = "Opel",
                        Model = "Chetkii",
                        Price = 18000,
                        Year = 2019
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 2,
                        Make = "Opel",
                        Model = "Takoi",
                        Price = 1000,
                        Year = 2018
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 2,
                        Make = "Opel",
                        Model = "Nikakoi",
                        Price = 8500,
                        Year = 2006
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 3,
                        Make = "Ferrari",
                        Model = "Monza",
                        Price = 800000,
                        Year = 2020
                    },
                    new Vehicle(currentPrimaryId++)
                    {
                        StoreID = 3,
                        Make = "Ferrari",
                        Model = "LaFerrari",
                        Price = 108000,
                        Year = 2013
                    }
                }
            );
        }
    }
}
