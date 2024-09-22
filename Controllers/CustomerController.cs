using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book_a_Table.Data;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomers()
        {
            // Return all customers
            return await _context.Customers.ToListAsync();
        }

        // GET: api/customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return customer;
        }

        // POST: api/customer
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomer(CustomerInfo customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustID }, customer);
        }

        // PUT: api/customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerInfo customer)
        {
            if (id != customer.CustID)
            {
                return BadRequest(); // Return 400 if ID mismatch
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.CustID == id))
                {
                    return NotFound(); // Return 404 if customer doesn't exist
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return 204 on successful update
        }

        // DELETE: api/customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 on successful deletion
        }
    }
}
