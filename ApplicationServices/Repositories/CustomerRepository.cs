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
    public class CustomerRepository : ICustomerRepository
    {
        public Customer AddCustomer(Customer customer)
        {
            return CustomerContainer.AddCustomer(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return CustomerContainer.GetAll();
        }

        public Customer GetById(int customerId)
        {
            return CustomerContainer.GetById(customerId);
        }

        public IEnumerable<Customer> GetStoreCustomers(int storeId)
        {
            return CustomerContainer.GetStoreCustomers(storeId);
        }

        public IEnumerable<Customer> GetUserCustomers(int userId)
        {
            return CustomerContainer.GetUserCustomers(userId);
        }

        public Customer ModifyCustomer(Customer customer)
        {
            return CustomerContainer.UpdateCustomer(customer);
        }

        public void RemoveCustomer(int customerId)
        {
            CustomerContainer.RemoveCustomer(customerId);
        }
    }
}
