using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.MenuItem;
using Book_a_Table.Services.IServices;

namespace Book_a_Table.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task AddMenuItemAsync(CreateMenuItemDTO menuItem)
        {
            await _menuItemRepository.AddMenuItemAsync(new MenuItem
            {
                ItemName = menuItem.ItemName,
                ItemPrice = menuItem.ItemPrice,
                IsAvailable = menuItem.IsAvailable
            });
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllMenuItemsAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            return await _menuItemRepository.GetMenuItemByIdAsync(menuItemId);
        }

        public async Task UpdateMenuItemAsync(int menuItemId, UpdateMenuItemDTO updateMenuItem)
        {
            var updateItem = await _menuItemRepository.GetMenuItemByIdAsync(menuItemId);

            if (updateItem == null)
            {
                return;
            }

            updateItem.ItemName = updateMenuItem.ItemName;
            updateItem.ItemPrice = updateMenuItem.ItemPrice;
            updateItem.IsAvailable = updateMenuItem.IsAvailable;
            
            await _menuItemRepository.UpdateMenuItemAsync(updateItem);
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            await _menuItemRepository.DeleteMenuItemAsync(menuItemId);
        }
    }
}