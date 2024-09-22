using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc; // Provides classes to build HTTP services in ASP.NET Core.
using Book_a_Table.Data; // Imports the application's data layer for database interactions.
using Book_a_Table.Models; // Imports the models, specifically `BoardInfo`, used in the controller.
using Microsoft.EntityFrameworkCore; 

namespace Book_a_Table.Controllers
{
    /* This Route attribute defines the URL pattern for the controller: 
    "api/[controller]" maps to "api/board" based on the class name. */
    [Route("api/[controller]")]
    [ApiController] /* This marks this class as an API controller, enabling 
                    features like automatic model validation. */

    public class BoardController : ControllerBase
    {
        /* This is Dependency Injection to provide access to the database context. */
        private readonly AppDbContext _context;

        /* This is constructor that injects the AppDbContext, allowing interaction 
        with the database. */
        public BoardController(AppDbContext context)
        {
            /* To store the injected DbContext instance in a private field. */
            _context = context; 
        }

        /* GET: api/board
         Fetches all board records from the database. */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardInfo>>> GetBoards()
        {
            // This Asynchronously returns a list of all boards from the database.
            return await _context.Boards.ToListAsync();
        }

        /* GET: api/board/{id}
        Fetches a single board record by its ID. */
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardInfo>> GetBoard(int id)
        {
            /* This will find a board asynchronously by its ID. */
            var board = await _context.Boards.FindAsync(id); 
            
            /* If no board is found, system will return a 404 Not Found response. */
            if (board == null)
            {
                return NotFound();
            }
            
            /* If found, system will return the board data then. */
            return board;
        }

        /* POST: api/board
        Adds a new board to the database. */
        [HttpPost]
        public async Task<ActionResult<BoardInfo>> PostBoard(BoardInfo board)
        {
            /* This adds the new board to the DbSet (local collection of boards). */
            _context.Boards.Add(board);

            /* This Asynchronously saves the changes (i.e., writes the new board to 
            the database). */
            await _context.SaveChangesAsync();

            // This returns 201 Created response with the location of the new board. */
            return CreatedAtAction(nameof(GetBoard), new { id = board.BoardID }, board); 
        }

        /* PUT: api/board/{id}
        Updates an existing board in the database by its ID. */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard(int id, BoardInfo board)
        {
            /* System will check here if the provided board ID in the URL matches 
            the board ID. If ID's don't match, it will return 400 Bad Request response. */
            if (id != board.BoardID)
            {
                return BadRequest(); 
            }

            /* To mark the board entity as modified in the context (so that Entity 
            Framework will update it). */
            _context.Entry(board).State = EntityState.Modified;

            try
            {
                /* To Asynchronously save the changes to the database. */
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /* If the board does not exist (due to concurrent updates or 
                deletions), system will return 404 Not Found. */
                if (!_context.Boards.Any(e => e.BoardID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-throw the exception if it's another type of error.
                }
            }

            /* To return 204 No Content to indicate the update was successful but 
            no response body is needed. */
            return NoContent();
        }

        /* DELETE: api/board/{id}
        Deletes a board by its ID. */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            // To find the board in the database by its ID.
            var board = await _context.Boards.FindAsync(id);

            // If the board doesn't exist, system returns 404 Not Found.
            if (board == null)
            {
                return NotFound();
            }

            // To Remove the board from the DbSet (marks it for deletion).
            _context.Boards.Remove(board);

            // To Asynchronously save changes to the database (performs the delete operation).
            await _context.SaveChangesAsync();

            // This returns 204 No Content to indicate the delete was successful.
            return NoContent();
        }
    }
}