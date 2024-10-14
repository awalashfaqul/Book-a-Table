using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.Table
{
    public class GetTableDTO
    {
        public int TableId { get; set; }

        public int TableNumber { get; set; }

        public int NumberOfSeats { get; set; }

        public bool IsAvailable { get; set; }

    }
}