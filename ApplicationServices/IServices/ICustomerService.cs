using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.IServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomerById(int customerId);

        Customer CreateCustomer(CustomerSummary customerSummary);

        Customer EditCustomer(CustomerSummary customerSummary, int customerId);

        void RemoveCustomer(int customerId);

        IEnumerable<Customer> GetStoreCustomers(int storeId);

        IEnumerable<Customer> GetUserCustomers(int userId);
    }
}
