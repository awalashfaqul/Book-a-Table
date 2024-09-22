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
    public class BoardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoardController(AppDbContext context)
        {
            _context = context; // Injecting the DbContext
        }

        // GET: api/board
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardInfo>>> GetBoards()
        {
            // Return all boards from the database asynchronously
            return await _context.Boards.ToListAsync();
        }

        // GET: api/board/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardInfo>> GetBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id); // Find a specific board by ID
            if (board == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return board; // Return the found board
        }

        // POST: api/board
        [HttpPost]
        public async Task<ActionResult<BoardInfo>> PostBoard(BoardInfo board)
        {
            // Add a new board to the database
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoard), new { id = board.BoardID }, board); // Return the created board
        }

        // PUT: api/board/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard(int id, BoardInfo board)
        {
            if (id != board.BoardID)
            {
                return BadRequest(); // Return 400 if the ID doesn't match
            }

            _context.Entry(board).State = EntityState.Modified; // Mark the entity as modified

            try
            {
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Boards.Any(e => e.BoardID == id))
                {
                    return NotFound(); // Return 404 if the board no longer exists
                }
                else
                {
                    throw; // Re-throw the exception if any other error occurs
                }
            }

            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE: api/board/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.Boards.Remove(board); // Remove the board
            await _context.SaveChangesAsync(); // Save changes asynchronously

            return NoContent(); // Return 204 No Content
        }
    }
}
