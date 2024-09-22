using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Data
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSets for each entity
        public DbSet<BoardInfo> Boards { get; set; }
        public DbSet<CustomerInfo> Customers { get; set; }
        public DbSet<BookingInfo> Bookings { get; set; }
        public DbSet<MenuItemInfo> MenuItems { get; set; }

        // Configuring relationships (optional, if needed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining relationships and any additional configuration
        }
    }
}