using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;
using Book_a_Table.Models.DTO.MenuItem;

namespace Book_a_Table.Services.IServices
{
    public interface IMenuItemService
    {
        Task AddMenuItemAsync(CreateMenuItemDTO menuItem);
        Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task UpdateMenuItemAsync(int menuItemId, UpdateMenuItemDTO updateMenuItem);
        Task DeleteMenuItemAsync(int menuItemId);
    }
}