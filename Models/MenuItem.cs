using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        public string? ItemName { get; set; }

        [Precision(18, 2)]
        public decimal ItemPrice { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
    }
}