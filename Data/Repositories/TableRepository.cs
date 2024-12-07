using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly BookATableDbContext _context;

        public TableRepository(BookATableDbContext context)
        {
            _context = context;
        }

        public async Task AddTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var tableList = await _context.Tables.ToListAsync();
            return tableList;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            return table;
        }

        public async Task<Table> GetTableWithBookingsAsync(int tableId)
        {
            return await _context.Tables.Include(t => t.Bookings).FirstOrDefaultAsync(t => t.TableId == tableId);
        }        

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if(table != null)
            {
                _context.Tables.Remove(table);
            }
            else
            {
                return;
            }

            await _context.SaveChangesAsync();
        
        }

        public async Task<Table> GetTableWithTableNumberAsync(int tableNumber)
        {
            return await _context.Tables
                  .Include(t => t.Bookings)
                  .FirstOrDefaultAsync(t => t.TableNumber == tableNumber);
        }

        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int numberOfPeople, DateTime startBookingDateTime)
        {
            DateTime endBookingDateTime = startBookingDateTime.AddHours(3);
            return await _context.Tables
                  .Where(t => t.NumberOfSeats >= numberOfPeople &&
                    !t.Bookings.Any(b => b.StartBookingDateTime <= endBookingDateTime && b.EndBookingDateTime >= startBookingDateTime))
                  .ToListAsync();
        }

        public async Task<bool> TableExistsAsync(int tableNumber)
        {
            return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
        }
    }
}