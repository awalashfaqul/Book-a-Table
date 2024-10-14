using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.MenuItem
{
    public class GetMenuItemDTO
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public bool IsAvailable { get; set; }
    }
}