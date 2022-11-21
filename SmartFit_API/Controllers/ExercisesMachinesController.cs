using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6Shop_API_EdisonChavarriaVasquez;
using SmartFit_API.Models;

namespace SmartFit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ExercisesMachinesController : ControllerBase
    {
        private readonly SmartFitContext _context;

        public ExercisesMachinesController(SmartFitContext context)
        {
            _context = context;
        }

        // GET: api/ExercisesMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercisesMachine>>> GetExercisesMachines()
        {
            return await _context.ExercisesMachines.ToListAsync();
        }

        // GET: api/ExercisesMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercisesMachine>> GetExercisesMachine(int id)
        {
            var exercisesMachine = await _context.ExercisesMachines.FindAsync(id);

            if (exercisesMachine == null)
            {
                return NotFound();
            }

            return exercisesMachine;
        }

        // PUT: api/ExercisesMachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercisesMachine(int id, ExercisesMachine exercisesMachine)
        {
            if (id != exercisesMachine.IdEjercicio)
            {
                return BadRequest();
            }

            _context.Entry(exercisesMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercisesMachineExists(id))
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

        // POST: api/ExercisesMachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExercisesMachine>> PostExercisesMachine(ExercisesMachine exercisesMachine)
        {
            _context.ExercisesMachines.Add(exercisesMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercisesMachine", new { id = exercisesMachine.IdEjercicio }, exercisesMachine);
        }

        // DELETE: api/ExercisesMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercisesMachine(int id)
        {
            var exercisesMachine = await _context.ExercisesMachines.FindAsync(id);
            if (exercisesMachine == null)
            {
                return NotFound();
            }

            _context.ExercisesMachines.Remove(exercisesMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercisesMachineExists(int id)
        {
            return _context.ExercisesMachines.Any(e => e.IdEjercicio == id);
        }
    }
}
