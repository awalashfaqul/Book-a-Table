using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.Table;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Services.IServices
{
    public interface ITableService
    {
        Task<IActionResult> AddTableAsync(CreateTableDTO table);
        Task<Table> GetTableByIdAsync(int tableId);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task UpdateTableAsync(int tableId, UpdateTableDTO updateTable);
        Task DeleteTableAsync(int tableId);
    }
}