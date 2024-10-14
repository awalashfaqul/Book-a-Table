using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100, MinimumLength =1, ErrorMessage = "Name must be up to 100 characters.")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CustomerPhone { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}