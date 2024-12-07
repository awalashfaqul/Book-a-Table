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
        private readonly ICustomerRepository _customerRepository;

        public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository, ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> AddBookingAsync(CreateBookingDTO createBookingDto)
        {
            var table = await _tableRepository.GetTableWithTableNumberAsync(createBookingDto.TableNumber);
            if (table == null)
            {
                return new NotFoundObjectResult("No table has been found!!");
            }

            if (table.NumberOfSeats < createBookingDto.NumberOfPeople)
            {
                return new BadRequestObjectResult("Small table for the group.");
            }

            var customer = await _customerRepository.GetCustomerForBookingAsync(createBookingDto.CustomerEmail);
            if (customer == null)
            {
                await _customerRepository.AddCustomerAsync(new Customer
                                                            {
                                                                CustomerName = createBookingDto.CustomerName,
                                                                CustomerEmail = createBookingDto.CustomerEmail
                                                            });
            }
            
            // Checking for booking conflicts
            var bookingExists = await _bookingRepository.BookingConflictAsync(createBookingDto.TableNumber, createBookingDto.StartBookingDateTime);
            if (bookingExists)
            {
                return new ConflictObjectResult("Table is already booked.");
            }

            if (customer == null)
            {
                customer = await _customerRepository.GetCustomerForBookingAsync(createBookingDto.CustomerEmail);
            }
          
            // Creating a new Booking object from the DTO
            var booking = new Booking
            {
                CustomerId = customer.CustomerId,
                TableId = table.TableId,
                TableNumber = table.TableNumber,
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                NumberOfPeople = createBookingDto.NumberOfPeople,
                StartBookingDateTime = createBookingDto.StartBookingDateTime,
                EndBookingDateTime = createBookingDto.StartBookingDateTime.AddHours(2),
            };

            // Use the repository to add the booking
            await _bookingRepository.AddBookingAsync(booking); 

            // Return the result with the created booking
            return new CreatedResult();
    }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();

            // // Use the repository to fetch all bookings
            // var bookings = await _bookingRepository.GetAllBookingsAsync(); 

            // // Map to GetBookingDTO
            // return bookings.Select(b => new GetBookingDTO
            // {
            //     BookingId = b.BookingId,
            //     CustomerId = b.CustomerId,
            //     CustomerName = b.Customer?.CustomerName, // Use null-conditional operator in case Customer is null
            //     TableId = b.TableId,
            //     TableNumber = b.Table?.TableNumber ?? 0, // Use null-coalescing operator to avoid null reference
            //     NumberOfPeople = b.NumberOfPeople,
            //     BookingDate = b.StartBookingDateTime.ToString("yyyy-MM-dd"),
            //     BookingTime = b.StartBookingDateTime.ToString("HH:mm")
            // });
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

        public async Task<IActionResult> UpdateBookingAsync(int bookingId, UpdateBookingDTO updateBooking)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            var table = await _tableRepository.GetTableWithTableNumberAsync(updateBooking.TableNumber);
            
            if (table == null)
            {
                return new NotFoundObjectResult("No table has been found!");
            }

            if (table.NumberOfSeats < updateBooking.NumberOfPeople)
            {
                return new BadRequestObjectResult("Small table for the group.");
            }
            
            var bookingExists = await _bookingRepository.BookingConflictAsync(updateBooking.TableNumber, updateBooking.StartBookingDateTime);
            
            if (bookingExists)
            {
                return new ConflictObjectResult("Table is already booked.");
            }
            
            var customer = await _customerRepository.GetCustomerForBookingAsync(updateBooking.CustomerEmail);

            if (customer == null)
            {
                await _customerRepository.AddCustomerAsync(new Customer
                {
                    CustomerName = updateBooking.CustomerName,
                    CustomerEmail = updateBooking.CustomerEmail
                });
            }
            else
            {
                customer.CustomerName = updateBooking.CustomerName;
                await _customerRepository.UpdateCustomerAsync(customer);
            }

            if (customer == null)
            {
                customer = await _customerRepository.GetCustomerForBookingAsync(updateBooking.CustomerEmail);
            }
            
            
            booking.CustomerId = customer.CustomerId;
            booking.TableId = table.TableId;
            booking.TableNumber = table.TableNumber;
            booking.CustomerName = customer.CustomerName;
            booking.CustomerEmail = customer.CustomerEmail;
            booking.NumberOfPeople = updateBooking.NumberOfPeople;
            booking.StartBookingDateTime = updateBooking.StartBookingDateTime;
            booking.EndBookingDateTime = updateBooking.StartBookingDateTime.AddHours(2);
      
      // Use the repository to update the booking
            await _bookingRepository.UpdateBookingAsync(booking);

            return new CreatedResult();
        }



        public async Task DeleteBookingAsync(int bookingId)
        {
            await _bookingRepository.DeleteBookingAsync(bookingId);
        }

        
    }
}