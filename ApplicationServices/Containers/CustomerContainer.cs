using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Containers
{
    public static class CustomerContainer
    {
        private static int currentPrimaryId = 1;

        private static List<Customer> customers { get; set; }

        static CustomerContainer()
        {
            initCustomers();
        }

        //todo: optional pagination
        public static IEnumerable<Customer> GetAll() => customers;

        public static Customer GetById(int customerId)
        {
            return customers.First(x => x.ID == customerId);
        }

        public static Customer AddCustomer(Customer customer)
        {
            var savingCustomer = new Customer(currentPrimaryId)
            {
                StoreID = customer.StoreID,
                Email = customer.Email,
                PrimaryFirstName = customer.PrimaryFirstName,
                PrimaryLastName = customer.PrimaryLastName,
                UserID = customer.UserID,
                CellPhone = customer.CellPhone
            };

            customers.Add(savingCustomer);
            currentPrimaryId++;
            return savingCustomer;
        }

        public static Customer UpdateCustomer(Customer customer)
        {
            var updatingCustomer = customers.First(x => x.ID == customer.ID);

            updatingCustomer.StoreID = customer.StoreID;
            updatingCustomer.Email = customer.Email;
            updatingCustomer.PrimaryFirstName = customer.PrimaryFirstName;
            updatingCustomer.PrimaryLastName = customer.PrimaryLastName;
            updatingCustomer.UserID = customer.UserID;
            updatingCustomer.CellPhone = customer.CellPhone;
            return updatingCustomer;
        }

        public static void RemoveCustomer(int customerId)
        {
            var removingCustomer = customers.First(x => x.ID == customerId);
            customers.Remove(removingCustomer);
        }

        public static IEnumerable<Customer> GetStoreCustomers(int storeId)
        {
            return customers.Where(x => x.StoreID == storeId);
        }

        public static IEnumerable<Customer> GetUserCustomers(int userId)
        {
            return customers.Where(x => x.UserID == userId);
        }


        private static void initCustomers()
        {
            customers = new List<Customer>() { 
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 1,
                    Email = "test@test.com",    
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Mike",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test2@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Brad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 3,
                    Email = "test3@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Basya",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 2,
                    UserID = 4,
                    Email = "test4@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Kolya",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 2,
                    UserID = 4,
                    Email = "test5@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Johan",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test6@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Amer",
                    PrimaryLastName = "Galetsky"
                }
            };
        }
    }
}
