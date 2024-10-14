using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;

namespace Book_a_Table.Data.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer); //Create
        Task<IEnumerable<Customer>> GetAllCustomersAsync(); //Read all
        Task<Customer> GetCustomerByIdAsync(int customerId); // Read by ID
        Task UpdateCustomerAsync(Customer customer); // Update
        Task DeleteCustomerAsync(int customerId); // Delete
    }
}