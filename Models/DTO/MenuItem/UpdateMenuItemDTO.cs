using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.MenuItem
{
    public class UpdateMenuItemDTO
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}