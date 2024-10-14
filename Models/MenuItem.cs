using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Menu item name should not be more than 50 characters.")]
        public string ItemName { get; set; }

        [Required]
        public double ItemPrice { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}