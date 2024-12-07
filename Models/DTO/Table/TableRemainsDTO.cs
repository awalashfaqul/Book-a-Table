using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.Table
{
    public class TableRemainsDTO
    {
        public int NumberOfPeople { get; set; }
        public DateTime StartBookingDateTime { get; set; }
    }
}