using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class Booking
    {
        [ForeignKey("Customer")] 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Table")] 
        public int TableId { get; set; }
        public Table Table { get; set; }

        [Key]
        public int BookingId { get; set; }
        public int TableNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public int NumberOfPeople { get; set; }

        public DateTime StartBookingDateTime { get; set; }
        public DateTime EndBookingDateTime { get; set; }
    }
}