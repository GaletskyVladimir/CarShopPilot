using ApplicationServices.Interfaces;
using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
            return customerRepository.GetById(customerId);
        }

        public Customer CreateCustomer(CustomerSummary customerSummary)
        {
            //todo mapper
            var customer = new Customer
            {
                Email = customerSummary.Email,
                StoreID = customerSummary.StoreID,
                CellPhone = customerSummary.CellPhone,
                PrimaryFirstName = customerSummary.PrimaryFirstName,
                PrimaryLastName = customerSummary.PrimaryLastName,
                UserID = customerSummary.UserID
            };
            return customerRepository.AddCustomer(customer);
        }

        public Customer EditCustomer(CustomerSummary customerSummary, int customerId)
        {
            var customer = customerRepository.GetById(customerId);
            customer.Email = customerSummary.Email;
            customer.StoreID = customerSummary.StoreID;
            customer.CellPhone = customerSummary.CellPhone;
            customer.PrimaryFirstName = customerSummary.PrimaryFirstName;
            customer.PrimaryLastName = customerSummary.PrimaryLastName;
            customer.UserID = customerSummary.UserID;
            return customerRepository.ModifyCustomer(customer);
        }

        public void RemoveCustomer(int customerId)
        {
            customerRepository.RemoveCustomer(customerId);
        }

        public IEnumerable<Customer> GetStoreCustomers(int storeId)
        {
            //store validation
            return customerRepository.GetStoreCustomers(storeId);
        }

        public IEnumerable<Customer> GetUserCustomers(int userId)
        {
            return customerRepository.GetUserCustomers(userId);
        }
    }
}
