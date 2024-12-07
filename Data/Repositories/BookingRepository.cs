using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookATableDbContext _context;

        public BookingRepository(BookATableDbContext context)
        {
            _context = context;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var booking = await _context.Bookings.ToListAsync();
            return booking;
            // return await _context.Bookings
            // .Include(b => b.Customer)
            // .Include(b => b.Table)
            // .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            return booking;
            // return await _context.Bookings
            // .Include(b => b.Customer)
            // .Include(b => b.Table)
            // .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            else
            {
                return;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> BookingConflictAsync(int tableId, DateTime startBookingDateTime)
        {
            DateTime endBookingDateTime = startBookingDateTime.AddHours(3);
            return await _context.Bookings.AnyAsync
            (
                b => b.TableId == tableId &&
                b.StartBookingDateTime < endBookingDateTime && 
                b.EndBookingDateTime > startBookingDateTime
            );
        }
    }
}