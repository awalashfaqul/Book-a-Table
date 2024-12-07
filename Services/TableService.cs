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
            var tableExists = await _tableRepository.TableExistsAsync(table.TableNumber);

            if (tableExists)
            {
                return new ConflictObjectResult("Table exists!!");
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

        public async Task UpdateTableAsync(int tableId, UpdateTableDTO updateTableDto)
        {
            var updateTable = await _tableRepository.GetTableByIdAsync(tableId);

            if (updateTable == null)
            {
                return;
            }

            updateTable.TableNumber = updateTableDto.TableNumber;
            updateTable.NumberOfSeats = updateTableDto.NumberOfSeats;

            await _tableRepository.UpdateTableAsync(updateTable);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var deleteTable = await _tableRepository.GetTableByIdAsync(tableId);

            if (deleteTable == null)
            {
                return;
            }

            await _tableRepository.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<Table>> GetAvailableTables(int numberOfPeople, DateTime startBookingDateTime)
        {
            return await _tableRepository.GetAvailableTablesAsync(numberOfPeople, startBookingDateTime);
        }
    }
}