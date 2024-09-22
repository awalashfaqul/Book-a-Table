using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book_a_Table.Data;
using Book_a_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_a_Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/menuitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemInfo>>> GetMenuItems()
        {
            // Return all menu items
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/menuitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemInfo>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return menuItem;
        }

        // POST: api/menuitem
        [HttpPost]
        public async Task<ActionResult<MenuItemInfo>> PostMenuItem(MenuItemInfo menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemID }, menuItem);
        }

        // PUT: api/menuitem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItemInfo menuItem)
        {
            if (id != menuItem.MenuItemID)
            {
                return BadRequest(); // Return 400 if ID mismatch
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MenuItems.Any(e => e.MenuItemID == id))
                {
                    return NotFound(); // Return 404 if menu item doesn't exist
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return 204 on successful update
        }

        // DELETE: api/menuitem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 on successful deletion
        }
    }
}
