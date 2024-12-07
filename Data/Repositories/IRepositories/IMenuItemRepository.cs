using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models;

namespace Book_a_Table.Data.Repositories.IRepositories
{
    public interface IMenuItemRepository
    {
        Task AddMenuItemAsync(MenuItem menuItem); // Create
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync(); // Read all
        Task<MenuItem> GetMenuItemByIdAsync(int menuItemId); // Read by ID
        Task UpdateMenuItemAsync(MenuItem menuItem); // Update
        Task DeleteMenuItemAsync(int menuItemId); // Delete
        
    }
}