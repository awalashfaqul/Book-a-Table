using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc; // Provides base classes for creating web APIs.
using Book_a_Table.Data; // Imports the application's data layer (AppDbContext).
using Book_a_Table.Models; // Imports the models (CustomerInfo) used in the controller.
using Microsoft.EntityFrameworkCore; 

namespace Book_a_Table.Controllers
{
    /* This is to define the API route as "api/customer". This automatically routes 
    incoming HTTP requests to this controller. */
    [Route("api/[controller]")]
    /* This is for marking the class as an API controller, enabling features like 
    automatic model validation. */
    [ApiController] 
    public class CustomerController : ControllerBase
    {
        /* This is tp inject the AppDbContext, allowing the controller to interact 
        with the database. */
        private readonly AppDbContext _context;

        /* This is the constructor that accepts AppDbContext as a dependency. */
        public CustomerController(AppDbContext context)
        {
            _context = context; // This stores the injected DbContext instance in a private field for later use.
        }

        /* GET: api/customer
        Handles GET requests to retrieve all customers from the database. */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomers()
        {
            /* This asynchronously retrieves the list of customers from the database 
            and returns it. */
            return await _context.Customers.ToListAsync();
        }

        /* GET: api/customer/{id}
        Handles GET requests to retrieve a specific customer by its ID. */
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetCustomer(int id)
        {
            /* This asynchronously retrieves the customer with the specified ID 
            from the database. */
            var customer = await _context.Customers.FindAsync(id);

            /* If no customer is found, this will return 404 Not Found. */
            if (customer == null)
            {
                return NotFound();
            }

            // Return the found customer as the response.
            return customer;
        }

        /* POST: api/customer
         Handles POST requests to create a new customer in the database. */
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomer(CustomerInfo customer)
        {
            /* This will add the new customer to the DbSet (local collection of 
            customers). */
            _context.Customers.Add(customer);

            /* This Asynchronously saves the new customer to the database. */
            await _context.SaveChangesAsync();

            /* This returns a 201 Created response with a reference to the newly 
            created customer. */
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustID }, customer);
        }

        /* PUT: api/customer/{id}
         Handles PUT requests to update an existing customer. */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerInfo customer)
        {
            /* This checks if the provided ID in the URL matches the ID of the 
            customer in the request body.*/
            if (id != customer.CustID)
            {
                return BadRequest(); // 400 Bad Request if the IDs don't match.
            }

            /* This will mark the customer entity as modified so that Entity 
            Framework will update it. */
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                // This asynchronously saves the changes to the database.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /* If no customer is found (due to concurrent updates or deletions), 
                this will return 404 Not Found. */
                if (!_context.Customers.Any(e => e.CustID == id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw; // Re-throw the exception for any other type of error.
                }
            }

            /* This returns 204 No Content to indicate that the update was 
            successful. */
            return NoContent();
        }

        /* DELETE: api/customer/{id}
         Handles DELETE requests to remove a customer by its ID. */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            /* Asynchronously finds the customer by its ID. */
            var customer = await _context.Customers.FindAsync(id);

            /* If no customer is found, returns 404 Not Found. */
            if (customer == null)
            {
                return NotFound();
            }

            /* This removes the customer from the DbSet (marks it for deletion). */
            _context.Customers.Remove(customer);

            /* This Asynchronously saves the changes after deleting the customer 
            from the database).*/
            await _context.SaveChangesAsync();

            /* This returns 204 No Content to indicate that the deletion was 
            successful. */
            return NoContent();
        }
    }
}
