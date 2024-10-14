using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;

namespace Book_a_Table.Data.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task AddBookingAsync(Booking booking); // Create
        Task<Booking> GetBookingByIdAsync(int bookingId); // Read by ID
        Task<IEnumerable<Booking>> GetAllBookingsAsync(); // Read all
        Task UpdateBookingAsync(Booking booking); // Update
        Task DeleteBookingAsync(int bookingId); // Delete
        Task<bool> BookingConflictAsync(int tableId, DateTime bookingTimeStarts);
    }
}