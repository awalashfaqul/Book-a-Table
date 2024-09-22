using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class MenuItemInfo
    {
        [Key]
        public int MenuItemID { get; set; } // Unique ID for each menu item
        public string? Name { get; set; } // Name of the dish
        public decimal Price { get; set; } // Price of the dish
        public bool IsAvailable { get; set; } // Availability of the dish
    }
}