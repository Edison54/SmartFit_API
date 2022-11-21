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
    public class MeasuresController : ControllerBase
    {
        private readonly SmartFitContext _context;

        public MeasuresController(SmartFitContext context)
        {
            _context = context;
        }

        // GET: api/Measures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measure>>> GetMeasures()
        {
            return await _context.Measures.ToListAsync();
        }

        // GET: api/Measures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measure>> GetMeasure(int id)
        {
            var measure = await _context.Measures.FindAsync(id);

            if (measure == null)
            {
                return NotFound();
            }

            return measure;
        }

        // PUT: api/Measures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasure(int id, Measure measure)
        {
            if (id != measure.IdMeasure)
            {
                return BadRequest();
            }

            _context.Entry(measure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasureExists(id))
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

        // POST: api/Measures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Measure>> PostMeasure(Measure measure)
        {
            _context.Measures.Add(measure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasure", new { id = measure.IdMeasure }, measure);
        }

        // DELETE: api/Measures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasure(int id)
        {
            var measure = await _context.Measures.FindAsync(id);
            if (measure == null)
            {
                return NotFound();
            }

            _context.Measures.Remove(measure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeasureExists(int id)
        {
            return _context.Measures.Any(e => e.IdMeasure == id);
        }
    }
}
