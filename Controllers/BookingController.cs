using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc; // Provides base classes for creating web APIs.
using Book_a_Table.Data; // Imports the application's data context (AppDbContext).
using Book_a_Table.Models; // Imports the models (BookingInfo) used by this controller.
using Microsoft.EntityFrameworkCore; 

namespace Book_a_Table.Controllers
{
    /* This will define the API route as "api/booking", automatically routing HTTP 
    requests to this controller. */
    [Route("api/[controller]")]
    /* This is to specify that this class is an API controller, enabling features 
    like model binding and validation. */
    [ApiController] 
    public class BookingController : ControllerBase
    {
        /* This will inject the AppDbContext, enabling interaction with the 
        database. */
        private readonly AppDbContext _context;

        /* This is constructor that receives the AppDbContext through dependency 
        injection. */
        public BookingController(AppDbContext context)
        {
            _context = context; // Stores the DbContext instance for later use.
        }

        /* GET: api/booking
        Handles GET requests to retrieve all bookings, including associated board 
        and customer details. */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingInfo>>> GetBookings()
        {
            /* This will asynchronously retrieve all bookings from the database, 
            including related Board and Customer entities via eager loading. */
            return await _context.Bookings
                .Include(b => b.Board) // This will include Board entity associated with the booking.
                .Include(b => b.Customer) // This will include Customer entity associated with the booking.
                .ToListAsync();
        }

        /* GET: api/booking/{id}
        Handles GET requests to retrieve a specific booking by its ID, including 
        associated board and customer details. */
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingInfo>> GetBooking(int id)
        {
            /* This will asynchronously retrieve a specific booking, including the 
            associated Board and Customer entities. */
            var booking = await _context.Bookings
                .Include(b => b.Board) // This will include Board entity.
                .Include(b => b.Customer) // This will include Customer entity.
                .FirstOrDefaultAsync(b => b.BookingID == id); // This will find the booking by its ID.

            /* If the booking is not found, return 404 Not Found. */
            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        /* POST: api/booking
         Handles POST requests to create a new booking in the database. */
        [HttpPost]
        public async Task<ActionResult<BookingInfo>> PostBooking(BookingInfo booking)
        {
            /* This will add the new booking to the DbSet (local collection of 
            bookings). */
            _context.Bookings.Add(booking);

            /* This will asynchronously save the new booking to the database. */
            await _context.SaveChangesAsync();

            /* This will return a 201 Created response, with a reference to the 
            newly created booking. */
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingID }, booking);
        }

        /* PUT: api/booking/{id}
         Handles PUT requests to update an existing booking by its ID. */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingInfo booking)
        {
            /* This will check if the provided ID in the URL matches the 
            booking's ID in the request body. */
            if (id != booking.BookingID)
            {
                return BadRequest(); // 400 Bad Request if IDs don't match.
            }

            /* This will mark the booking entity as modified to indicate an update. */
            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                /* This will asynchronously save the changes to the database. */
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /* If the booking is not found due to a concurrent update/deletion, 
                this will return 404 Not Found. */
                if (!_context.Bookings.Any(e => e.BookingID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-throw the exception for other errors.
                }
            }

            /* This will return 204 No Content to indicate that the update was 
            successful. */
            return NoContent();
        }

        /* DELETE: api/booking/{id}
        Handles DELETE requests to remove a booking by its ID. */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            /* This will asynchronously find the booking by its ID. */
            var booking = await _context.Bookings.FindAsync(id);

            /* If the booking is not found, return 404 Not Found. */
            if (booking == null)
            {
                return NotFound();
            }

            /* This will remove the booking from the DbSet (will mark it for deletion). */
            _context.Bookings.Remove(booking);

            /* This will asynchronously save the changes after deleting the booking 
            from the database. */
            await _context.SaveChangesAsync();

            /* This will return 204 No Content to indicate that the deletion is 
            successful. */
            return NoContent();
        }
    }
}
