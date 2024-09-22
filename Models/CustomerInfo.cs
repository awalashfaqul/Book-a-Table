using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustID { get; set; } // Unique ID for each customer
        public required string CustFirstname { get; set; } // First name of the customer
        public required string CustLastname { get; set; } // Last name of the customer
        public required string CustPhone { get; set; } // Phone number
        public required string CustEmail { get; set; } // Email address
        public string? CustStreet { get; set; } // Street address
        public string? CustHousenum { get; set; } // House number
        public required string CustCity { get; set; } // City
        public required string CustZipcode { get; set; } // Zip code
        public string? CustState { get; set; } // State
    }
}