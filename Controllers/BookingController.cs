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
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingInfo>>> GetBookings()
        {
            // Return all bookings, including board and customer info
            return await _context.Bookings
                .Include(b => b.Board)
                .Include(b => b.Customer)
                .ToListAsync();
        }

        // GET: api/booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingInfo>> GetBooking(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Board)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.BookingID == id);

            if (booking == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return booking;
        }

        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<BookingInfo>> PostBooking(BookingInfo booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingID }, booking);
        }

        // PUT: api/booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingInfo booking)
        {
            if (id != booking.BookingID)
            {
                return BadRequest(); // Return 400 if ID mismatch
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(e => e.BookingID == id))
                {
                    return NotFound(); // Return 404 if booking doesn't exist
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return 204 on successful update
        }

        // DELETE: api/booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 on successful deletion
        }
    }
}
