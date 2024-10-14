using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.Booking;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Services.IServices
{
    public interface IBookingService
    {
        Task<IActionResult> AddBookingAsync(CreateBookingDTO createBooking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<GetBookingDTO>> GetAllBookingsAsync();
        Task<string> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateBooking);
        Task DeleteBookingAsync(int bookingId);
    }
}