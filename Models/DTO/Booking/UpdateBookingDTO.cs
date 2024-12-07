using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.Booking
{
    public class UpdateBookingDTO
    {
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartBookingDateTime { get; set; }
        
    }
}