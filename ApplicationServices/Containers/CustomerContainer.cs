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

        private static void initCustomers()
        {
            customers = new List<Customer>() { 
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",    
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                },
                new Customer(currentPrimaryId++)
                {
                    StoreID = 1,
                    UserID = 2,
                    Email = "test@test.com",
                    CellPhone = "+1 2323 232 323",
                    PrimaryFirstName = "Vlad",
                    PrimaryLastName = "Galetsky"
                }
            };
        }
    }
}
