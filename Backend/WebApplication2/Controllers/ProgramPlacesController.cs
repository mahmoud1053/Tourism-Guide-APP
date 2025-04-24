using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramPlacesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProgramPlacesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProgramPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Program_Places>>> GetProgramPlaces()
        {
            return await _context.Program_Place.Include(pp => pp.Program).ToListAsync();
        }

        // GET: api/ProgramPlaces/5
        [HttpGet("{programId}/{name}")]
        public async Task<ActionResult<Program_Places>> GetProgramPlace(int programId, string name)
        {
            var programPlace = await _context.Program_Place
                .Include(pp => pp.Program)
                .FirstOrDefaultAsync(pp => pp.Program_Id == programId && pp.Name == name);

            if (programPlace == null)
            {
                return NotFound();
            }

            return programPlace;
        }

        // POST: api/ProgramPlaces
        [HttpPost]
        public async Task<ActionResult<Program_Places>> PostProgramPlace(Program_Places programPlace)
        {
            _context.Program_Place.Add(programPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProgramPlace),
                new { programId = programPlace.Program_Id, name = programPlace.Name },
                programPlace);
        }

        // PUT: api/ProgramPlaces/5
        [HttpPut("{programId}/{name}")]
        public async Task<IActionResult> PutProgramPlace(int programId, string name, Program_Places programPlace)
        {
            if (programId != programPlace.Program_Id || name != programPlace.Name)
            {
                return BadRequest();
            }

            _context.Entry(programPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramPlaceExists(programId, name))
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

        // DELETE: api/ProgramPlaces/5
        [HttpDelete("{programId}/{name}")]
        public async Task<IActionResult> DeleteProgramPlace(int programId, string name)
        {
            var programPlace = await _context.Program_Place
                .FirstOrDefaultAsync(pp => pp.Program_Id == programId && pp.Name == name);
            if (programPlace == null)
            {
                return NotFound();
            }

            _context.Program_Place.Remove(programPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramPlaceExists(int programId, string name)
        {
            return _context.Program_Place.Any(pp => pp.Program_Id == programId && pp.Name == name);
        }
    }
}
