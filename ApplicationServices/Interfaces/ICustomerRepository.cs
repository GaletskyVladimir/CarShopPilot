using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int customerId);

        Customer AddCustomer(Customer customer);

        Customer ModifyCustomer(Customer customer);

        void RemoveCustomer(int customerId);

        IEnumerable<Customer> GetStoreCustomers(int storeId);

        IEnumerable<Customer> GetUserCustomers(int userId);
    }
}
