using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.Table;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IActionResult> AddTableAsync(CreateTableDTO table)
        {
            var tableBooked = await _tableRepository.TableBookedAsync(table.TableNumber);

            if (tableBooked)
            {
                return new ConflictObjectResult("Table is already Booked.");
            }

            await _tableRepository.AddTableAsync(new Table
            {
                TableNumber = table.TableNumber,
                NumberOfSeats = table.NumberOfSeats
            });

            return new CreatedResult();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllTablesAsync();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _tableRepository.GetTableByIdAsync(tableId);
        }

        public async Task UpdateTableAsync(int tableId, UpdateTableDTO updateTable)
        {
            var tableToUpdate = await _tableRepository.GetTableByIdAsync(tableId);

            if (tableToUpdate == null)
            {
                return;
            }

            tableToUpdate.TableNumber = updateTable.TableNumber;
            tableToUpdate.NumberOfSeats = updateTable.NumberOfSeats;

            await _tableRepository.UpdateTableAsync(tableToUpdate);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var tableToDelete = await _tableRepository.GetTableByIdAsync(tableId);

            if (tableToDelete == null)
            {
                return;
            }

            await _tableRepository.DeleteTableAsync(tableId);
        }
    }
}