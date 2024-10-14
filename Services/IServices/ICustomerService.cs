using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO;
using Book_a_Table.Models.DTO.Customer;

namespace Book_a_Table.Services.IServices
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CreateCustomerDTO customer);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(int customerId, UpdateCustomerDTO updateCustomer);
        Task DeleteCustomerAsync(int customerId);
    }
}