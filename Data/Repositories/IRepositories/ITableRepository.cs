using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;

namespace Book_a_Table.Data.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task AddTableAsync(Table table); // Create
        Task<Table> GetTableByIdAsync(int tableId); // Read by ID
        Task<IEnumerable<Table>> GetAllTablesAsync(); //Read all
        Task UpdateTableAsync(Table table); // Update
        Task DeleteTableAsync(int tableId); // Delete
        Task<Table> GetTableWithTableNumberAsync(int tableNumber);
        Task<bool> TableExistsAsync(int tableNumber);
        Task<IEnumerable<Table>> GetAvailableTablesAsync(int numberOfPeople, DateTime startBookingDateTime);

    }
}