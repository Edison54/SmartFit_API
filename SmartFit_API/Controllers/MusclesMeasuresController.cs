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
    public class MusclesMeasuresController : ControllerBase
    {
        private readonly SmartFitContext _context;

        public MusclesMeasuresController(SmartFitContext context)
        {
            _context = context;
        }

        // GET: api/MusclesMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusclesMeasure>>> GetMusclesMeasures()
        {
            return await _context.MusclesMeasures.ToListAsync();
        }

        // GET: api/MusclesMeasures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusclesMeasure>> GetMusclesMeasure(int id)
        {
            var musclesMeasure = await _context.MusclesMeasures.FindAsync(id);

            if (musclesMeasure == null)
            {
                return NotFound();
            }

            return musclesMeasure;
        }

        // PUT: api/MusclesMeasures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusclesMeasure(int id, MusclesMeasure musclesMeasure)
        {
            if (id != musclesMeasure.IdMuscle)
            {
                return BadRequest();
            }

            _context.Entry(musclesMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusclesMeasureExists(id))
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

        // POST: api/MusclesMeasures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusclesMeasure>> PostMusclesMeasure(MusclesMeasure musclesMeasure)
        {
            _context.MusclesMeasures.Add(musclesMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusclesMeasure", new { id = musclesMeasure.IdMuscle }, musclesMeasure);
        }

        // DELETE: api/MusclesMeasures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusclesMeasure(int id)
        {
            var musclesMeasure = await _context.MusclesMeasures.FindAsync(id);
            if (musclesMeasure == null)
            {
                return NotFound();
            }

            _context.MusclesMeasures.Remove(musclesMeasure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusclesMeasureExists(int id)
        {
            return _context.MusclesMeasures.Any(e => e.IdMuscle == id);
        }
    }
}
