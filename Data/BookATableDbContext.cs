using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Book_a_Table.Data
{
    public class BookATableDbContext:DbContext
    {
        public BookATableDbContext(DbContextOptions<BookATableDbContext> options):base (options)
        {
            
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
            
        //     modelBuilder.Entity<Customer>().HasData
        //     (
        //         new Customer {CustomerId = 1, CustomerName = "Gibbs Andersson", CustomerPhone = "0706574896", CustomerEmail ="gibbs.andersson@ght.se", CustomerAddress = "Vällingby, Stockholm"},
        //         new Customer {CustomerId = 2, CustomerName = "Hobbs Johansson", CustomerPhone = "0705678396", CustomerEmail ="Hobbs.johansson@lsd.se", CustomerAddress = "Huddinge, Stockholm"},
        //         new Customer {CustomerId = 3, CustomerName = "Tobbs Huge", CustomerPhone = "0759074596", CustomerEmail ="tobbs.huge@xyz.se", CustomerAddress = "Bromma, Stockholm"}
        //     );
        // }
    }
}