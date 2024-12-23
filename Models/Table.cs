using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        public int TableNumber { get; set; }

        public int NumberOfSeats { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}