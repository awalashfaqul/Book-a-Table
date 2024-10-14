using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models.DTO.MenuItem;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpPost]
        [Route("CREATE_MenuItem")]
        public async Task<IActionResult> AddMenuItemAsync(CreateMenuItemDTO createMenuItemDto)
        {
            await _menuItemService.AddMenuItemAsync(createMenuItemDto);
            return Created();
        }

        [HttpGet]
        [Route("READ_All_MenuItems")]
        public async Task<IActionResult> GetMenuItemsAsync()
        {
            return Ok(await _menuItemService.GetAllMenuItemsAsync());
        }

        [HttpGet]
        [Route("READ_MenuItem_By_Id")]
        public async Task<IActionResult> GetMenuItemById(int menuItemId)
        {
            return Ok(await _menuItemService.GetMenuItemByIdAsync(menuItemId));
        }

        [HttpPut]
        [Route("UPDATE_MenuItem")]
        public async Task<IActionResult> UpdateMenuItemAsync(int menuItemId, UpdateMenuItemDTO updateMenuItemDto)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItemId, updateMenuItemDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("DELETE_MenuItem")]
        public async Task<IActionResult> DeleteMenuItemAsync(int menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);
            return NoContent();
        }
    }
}