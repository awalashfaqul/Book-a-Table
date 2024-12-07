using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookATableDbContext _context;
        public CustomerRepository(BookATableDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
             await _context.Customers.AddAsync(customer);
             await _context.SaveChangesAsync();

        }
        
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customersList = await _context.Customers.ToListAsync();
            return customersList;
        }

        public async Task<Customer> GetCustomerByIdAsync(int CustomerId)
        {
            var customer = await _context.Customers.FindAsync(CustomerId);
            //if (customer != null)
            //{
                return customer;
            //}

            //return null;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int CustomerId)
        {
            var customer = await _context.Customers.FindAsync(CustomerId);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
            }
            else
            {
                return;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerForBookingAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerEmail == email);
        }
    }
}