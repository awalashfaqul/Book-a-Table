using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models.DTO.Booking;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("CREATE_Booking")]
        public async Task<IActionResult> AddBookingAsync(CreateBookingDTO createBookingDto)
        {
            return await _bookingService.AddBookingAsync(createBookingDto);
        }

        [HttpGet]
        [Route("READ_All_Bookings")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            //return Ok(await _bookingService.GetAllBookingsAsync());
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet]
        [Route("READ_Booking_By_Id")]
        public async Task<IActionResult> GetBookingByIdAsync(int bookingId)
        {
            return Ok(await _bookingService.GetBookingByIdAsync(bookingId));
        }   

        [HttpPut]
        [Route("UPDATE_Booking")]
        // public async Task<IActionResult> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateBookingDto)
        // {
        //     await _bookingService.UpdateBookingAsync(bookingId, updateBookingDto);
        //     return NoContent();
        // }

        public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] UpdateBookingDTO updateBookingDto)
        {
            var result = await _bookingService.UpdateBookingAsync(bookingId, updateBookingDto);

            if (result.StartsWith("Booking with ID"))
            {
                return NotFound(result); // Return NotFound if the booking is not found
            }

            return NoContent(); // Return No Content if the update is successful
        }

        [HttpDelete]
        [Route("DELETE_Booking")]
        public async Task<IActionResult> DeleteBookingAsync(int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return NoContent();
        }  
    }
}