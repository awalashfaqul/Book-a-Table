using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_a_Table.Models.DTO.Customer
{
    public class GetCustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}