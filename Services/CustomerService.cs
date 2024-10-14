using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.Customer;
using Book_a_Table.Services.IServices;

namespace Book_a_Table.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(CreateCustomerDTO customer)
        {
            await _customerRepository.AddCustomerAsync(new Customer
            {
                CustomerName = customer.CustomerName,
                CustomerPhone = customer.CustomerPhone,
                CustomerEmail = customer.CustomerEmail
            });
        }

public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task UpdateCustomerAsync(int customerId, UpdateCustomerDTO updateCustomer)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            customer.CustomerName = updateCustomer.CustomerName;
            customer.CustomerPhone = updateCustomer.CustomerPhone;
            customer.CustomerEmail = updateCustomer.CustomerEmail;

            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}