using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Book_a_Table.Models
{
    public class BookingInfo
    {
        [Key]
        public int BookingID { get; set; } // Unique ID for each booking

        [ForeignKey("BoardInfo")]
        public int BoardID { get; set; } // Foreign key for board
        //public BoardInfo? Board { get; set; } // Navigation property for board
        
        [ForeignKey("CustomerInfo")]
        public int CustID { get; set; } // Foreign key for customer
        //public CustomerInfo? Customer { get; set; } // Navigation property for customer

        public DateTime BookingDate { get; set; } // Booking date
        public DateTime BookingTime { get; set; } // Booking time
        public int TotalGuests { get; set; } // Number of guests
        
    }
}