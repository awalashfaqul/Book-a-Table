using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc; // Provides classes for building web APIs.
using Book_a_Table.Data; // Imports the application's data context (AppDbContext).
using Book_a_Table.Models; // Imports the model classes (MenuItemInfo) used in the application.
using Microsoft.EntityFrameworkCore; 

namespace Book_a_Table.Controllers
{
    /* Defining the API route as "api/menuitem", routing incoming HTTP requests 
    to this controller. */
    [Route("api/[controller]")]
    [ApiController] /* This specifies that this class is an API controller, enabling 
                    automatic model binding, validation, and more. */ 
    public class MenuItemController : ControllerBase
    {
        /* To inject the AppDbContext to allow interaction with the database. */ 
        private readonly AppDbContext _context;

        /* This is constructor that receives the AppDbContext via dependency injection. */ 
        public MenuItemController(AppDbContext context)
        {
            _context = context; // This will store the context for later use in database operations.
        }

        /* GET: api/menuitem 
        Handles GET requests to retrieve all menu items from the database. */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemInfo>>> GetMenuItems()
        {
            /* Asynchronously returns a list of all menu items from the database. */ 
            return await _context.MenuItems.ToListAsync();
        }

        /* GET: api/menuitem/{id}
        Handles GET requests to retrieve a specific menu item by its ID. */
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItemInfo>> GetMenuItem(int id)
        {
            /* Asynchronously retrieves a specific menu item based on its ID. */
            var menuItem = await _context.MenuItems.FindAsync(id);

            /* If the menu item with the given ID is not found, return a 404 Not 
            Found response. */
            if (menuItem == null)
            {
                return NotFound(); 
            }

            /* This will return the found menu item. */
            return menuItem;
        }

        /* POST: api/menuitem
        Handles POST requests to create a new menu item in the database.*/
        [HttpPost]
        public async Task<ActionResult<MenuItemInfo>> PostMenuItem(MenuItemInfo menuItem)
        {
            /* this will add the new menu item to the DbSet (local collection of 
            menu items). */
            _context.MenuItems.Add(menuItem);

            /* This will asynchronously save the new menu item to the database. */
            await _context.SaveChangesAsync();

            /* This will return a 201 Created response, with a reference to the 
            newly created menu item. */
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuItemID }, menuItem);
        }

        /* PUT: api/menuitem/{id}
        Handles PUT requests to update an existing menu item by its ID. */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItemInfo menuItem)
        {
            /* Checks if the provided ID in the URL matches the menu item's ID in 
            the request body. */
            if (id != menuItem.MenuItemID)
            {
                return BadRequest(); //This will return 400 Bad Request if the IDs don't match.
            }

            /* This will mark the menu item as modified to signal that it should 
            be updated. */
            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                /* This will asynchronously save the changes to the database. */
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /* If the menu item is not found (due to concurrent modification), 
                return a 404 Not Found response. */
                if (!_context.MenuItems.Any(e => e.MenuItemID == id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw; // Re-throw the exception for other errors.
                }
            }

            /* This will return 204 No Content to indicate the update was successful. */
            return NoContent();
        }

        /* DELETE: api/menuitem/{id}
         Handles DELETE requests to remove a menu item by its ID. */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            /* This will asynchronously retrieves the menu item by its ID. */
            var menuItem = await _context.MenuItems.FindAsync(id);

            /* If the menu item is not found, return a 404 Not Found response. */
            if (menuItem == null)
            {
                return NotFound(); 
            }

            /* This will mark the menu item for deletion. */
            _context.MenuItems.Remove(menuItem);

            /* This will asynchronously saves the changes (actually removes the 
            menu item from the database). */
            await _context.SaveChangesAsync();

            /* This will return 204 No Content to indicate successful deletion. */
            return NoContent();
        }
    }
}
