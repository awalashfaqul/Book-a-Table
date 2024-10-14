using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Data.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly BookATableDbContext _context;

        public MenuItemRepository(BookATableDbContext context)
        {
            _context = context;
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            var ItemList = await _context.MenuItems.ToListAsync();
            return ItemList;
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            return menuItem;
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            if(menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
            }
            else
            {
                return;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ItemAvailableAsync(string ItemName)
        {
            return await _context.MenuItems.AnyAsync(m => m.ItemName == ItemName);
        }
    }
}