using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models.DTO.Table;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        [Route("CREATE_Table")]
        public async Task<IActionResult> AddTableAsync(CreateTableDTO createTableDto)
        {
            return await _tableService.AddTableAsync(createTableDto);
        }

        [HttpGet]
        [Route("READ_All_Tables")]
        public async Task<IActionResult> GetAllTablesAsync()
        {
            return Ok(await _tableService.GetAllTablesAsync());
        }

        [HttpGet]
        [Route("READ_Table_By_Id")]
        public async Task<IActionResult> GetTableByIdAsync(int tableId)
        {
            return Ok(await _tableService.GetTableByIdAsync(tableId));
        }

        [HttpPut]
        [Route("UPDATE_Table")]
        public async Task<IActionResult> UpdateTableAsync(int tableId, UpdateTableDTO updateTableDto)
        {
            await _tableService.UpdateTableAsync(tableId, updateTableDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("DELETE_Table")]
        public async Task<IActionResult> DeleteTableAsync(int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return NoContent();
        }

        [HttpGet]
        [Route("Available_Tables")]
        public async Task<IActionResult> GetAvailableTables(TableRemainsDTO tableRemainsDto)
        {
        return Ok(await _tableService.GetAvailableTables(tableRemainsDto.NumberOfPeople, tableRemainsDto.StartBookingDateTime));
        }
    }
}        