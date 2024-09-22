using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class BoardInfo
    {
        [Key]
        public int BoardID { get; set; } // Unique ID for each board
        public int BoardNum { get; set; } // Board number
        public int TotalSeats { get; set; } // Total seats available at the board
        public string? BoardType { get; set; } // Board type (Single, Family, Conference)
    }
}