using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.Booking;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITableRepository _tableRepository;

        // private readonly ICustomerRepository _customerRepository;

        public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository)
        {
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
            // _customerRepository = customerRepository;
        }

        public async Task<IActionResult> AddBookingAsync(CreateBookingDTO createBookingDto)
        {
            // Validating the table existence and capacity
            var table = await _tableRepository.GetTableWithBookingsAsync(createBookingDto.TableId);
            if (table == null)
            {
                return new NotFoundObjectResult("Table not found!!");
            }

            if (table.NumberOfSeats < createBookingDto.NumberOfPeople)
            {
                return new BadRequestObjectResult("Table does not have enough seats.");
            }

            // Parsing BookingDate and BookingTime to create StartBookingDateTime
            var startBookingDateTime = DateTime.ParseExact(createBookingDto.BookingDate + " " + createBookingDto.BookingTime, "yyyy-MM-dd HH:mm", null);
            var endBookingDateTime = startBookingDateTime.AddHours(2); // Assuming 2 hours booking duration

            // Checking for booking conflicts
            var bookingExists = await _bookingRepository.BookingConflictAsync(createBookingDto.TableId, startBookingDateTime);
            if (bookingExists)
            {
                return new ConflictObjectResult("Table is already booked for this date and time");
            }

          
            // Creating a new Booking object from the DTO
            var booking = new Booking
            {
                CustomerId = createBookingDto.CustomerId,
                TableId = createBookingDto.TableId,
                NumberOfPeople = createBookingDto.NumberOfPeople,
                StartBookingDateTime = startBookingDateTime,
                EndBookingDateTime = endBookingDateTime
            };

            // Use the repository to add the booking
            await _bookingRepository.AddBookingAsync(booking); 

            // Return the result with the created booking
            return new CreatedAtActionResult(nameof(GetBookingByIdAsync), "Booking", new { bookingId = booking.BookingId }, booking);
    }

        public async Task<IEnumerable<GetBookingDTO>> GetAllBookingsAsync()
        {
            //return await _bookingRepository.GetAllBookingsAsync();

            // Use the repository to fetch all bookings
            var bookings = await _bookingRepository.GetAllBookingsAsync(); 

            // Map to GetBookingDTO
            return bookings.Select(b => new GetBookingDTO
            {
                BookingId = b.BookingId,
                CustomerId = b.CustomerId,
                CustomerName = b.Customer?.CustomerName, // Use null-conditional operator in case Customer is null
                TableId = b.TableId,
                TableNumber = b.Table?.TableNumber ?? 0, // Use null-coalescing operator to avoid null reference
                NumberOfPeople = b.NumberOfPeople,
                BookingDate = b.StartBookingDateTime.ToString("yyyy-MM-dd"),
                BookingTime = b.StartBookingDateTime.ToString("HH:mm")
            });
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _bookingRepository.GetBookingByIdAsync(bookingId);
        }

        // public async Task<IActionResult> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateBookingDto)
        // {
        //     // Find the existing booking by bookingId using the repository
        //     var existingBooking = await _bookingRepository.GetBookingByIdAsync(bookingId);

        //     // Check if the booking exists
        //     if (existingBooking == null)
        //     {
        //         return NotFound($"Booking with ID {bookingId} not found.");
        //     }

        //     // Update the booking details
        //     existingBooking.CustomerId = updateBookingDto.CustomerId;
        //     existingBooking.TableId = updateBookingDto.TableId;
        //     existingBooking.NumberOfPeople = updateBookingDto.NumberOfPeople;

        //     // Parse BookingDate and BookingTime to set StartBookingDateTime and EndBookingDateTime
        //     DateTime startDateTime = DateTime.ParseExact(updateBookingDto.BookingDate + " " + updateBookingDto.BookingTime, "yyyy-MM-dd HH:mm", null);
        //     existingBooking.StartBookingDateTime = startDateTime;
        //     existingBooking.EndBookingDateTime = startDateTime.AddHours(2); // Assuming a 2-hour duration for the booking

        //     // Use the repository to update the booking
        //     await _bookingRepository.UpdateBookingAsync(existingBooking);

        //     return NoContent(); // Return 204 No Content if the update is successful
        // }

        public async Task<string> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateBookingDto)
        {
            // Find the existing booking by bookingId using the repository
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(bookingId);

            // Check if the booking exists
            if (existingBooking == null)
            {
                return $"Booking with ID {bookingId} not found.";
            }

            // Update the booking details
            existingBooking.CustomerId = updateBookingDto.CustomerId;
            existingBooking.TableId = updateBookingDto.TableId;
            existingBooking.NumberOfPeople = updateBookingDto.NumberOfPeople;

            // Parse BookingDate and BookingTime to set StartBookingDateTime and EndBookingDateTime
            DateTime startDateTime = DateTime.ParseExact(updateBookingDto.BookingDate + " " + updateBookingDto.BookingTime, "yyyy-MM-dd HH:mm", null);
            existingBooking.StartBookingDateTime = startDateTime;
            existingBooking.EndBookingDateTime = startDateTime.AddHours(2); // Assuming a 2-hour duration for the booking

            // Use the repository to update the booking
            await _bookingRepository.UpdateBookingAsync(existingBooking);

            return "Booking updated successfully."; // Return success message
        }



        public async Task DeleteBookingAsync(int bookingId)
        {
            await _bookingRepository.DeleteBookingAsync(bookingId);
        }

        
    }
}