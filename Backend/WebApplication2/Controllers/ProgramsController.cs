using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProgramsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Programs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>> GetPrograms()
        {
            // Fetch all programs and include related ProgramPlaces
            return await _context.Programs
                .Include(p => p.ProgramPlaces)
                .ToListAsync();
        }

        // GET: api/Programs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programs>> GetProgram(int id)
        {
            var program = await _context.Programs
                .Include(p => p.ProgramPlaces) // Include related ProgramPlaces
                .FirstOrDefaultAsync(p => p.Program_Id == id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        // POST: api/Programs
        [HttpPost]
        public async Task<ActionResult<Programs>> PostProgram(Programs program)
        {
            // Add the new program to the database
            _context.Programs.Add(program);
            await _context.SaveChangesAsync();

            // Return the created program with a status code
            return CreatedAtAction(nameof(GetProgram), new { id = program.Program_Id }, program);
        }

        // PUT: api/Programs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(int id, Programs program)
        {
            if (id != program.Program_Id)
            {
                return BadRequest();
            }

            _context.Entry(program).State = EntityState.Modified;

            try
            {
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Programs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var program = await _context.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(program);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if the program exists
        private bool ProgramExists(int id)
        {
            return _context.Programs.Any(e => e.Program_Id == id);
        }
    }
}
