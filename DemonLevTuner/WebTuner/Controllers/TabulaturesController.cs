using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTuner.Data;
using WebTuner.Entity;

namespace WebTuner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabulaturesController : ControllerBase
    {
        private readonly DataContextTabulature _context;

        public TabulaturesController(DataContextTabulature context)
        {
            _context = context;
        }

        // GET: api/Tabulatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tabulature>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Tabulatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tabulature>> GetTabulature(int id)
        {
            var tabulature = await _context.Songs.FindAsync(id);

            if (tabulature == null)
            {
                return NotFound();
            }

            return tabulature;
        }

        // PUT: api/Tabulatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTabulature(int id, Tabulature tabulature)
        {
            if (id != tabulature.Id)
            {
                return BadRequest();
            }

            _context.Entry(tabulature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabulatureExists(id))
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

        // POST: api/Tabulatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tabulature>> PostTabulature(Tabulature tabulature)
        {
            _context.Songs.Add(tabulature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTabulature", new { id = tabulature.Id }, tabulature);
        }

        // DELETE: api/Tabulatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTabulature(int id)
        {
            var tabulature = await _context.Songs.FindAsync(id);
            if (tabulature == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(tabulature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TabulatureExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
