using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.Booking
{
    public class GetBookingDTO
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfPeople { get; set; }        
        public string BookingDate { get; set; } // Format: "yyyy-MM-dd"
    public string BookingTime { get; set; } // Format: "HH:mm"
    }
}