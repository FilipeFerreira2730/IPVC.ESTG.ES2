using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodpostalsController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public CodpostalsController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Codpostals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Codpostals>>> GetCodpostals()
        {
            if (_context.Codpostals == null)
            {
                return NotFound();
            }

            return await _context.Codpostals.ToListAsync();
        }

        // GET: api/Codpostals/5
        [HttpGet("{codpostal}")]
        public async Task<ActionResult<Codpostals>> GetCodpostal(string codpostal)
        {
            if (_context.Codpostals == null)
            {
                return NotFound();
            }

            var codpostalEntity = await _context.Codpostals.FindAsync(codpostal);

            if (codpostalEntity == null)
            {
                return NotFound();
            }

            return codpostalEntity;
        }

        // PUT: api/Codpostals/5
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{codpostal}")]
        public async Task<IActionResult> PutCodpostal(string codpostal, Codpostals codpostalEntity)
        {
            if (codpostal != codpostalEntity.codpostal1)
            {
                return BadRequest();
            }

            _context.Entry(codpostalEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodpostalExists(codpostal))
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

        // POST: api/Codpostals
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Codpostals>> PostCodpostal(Codpostals codpostal)
        {
            if (_context.Codpostals == null)
            {
                return Problem("Entity set 'ES2DbContext.Codpostals' is null.");
            }

            _context.Codpostals.Add(codpostal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodpostal", new { codpostal = codpostal.codpostal1 }, codpostal);
        }

        // DELETE: api/Codpostals/5
        [HttpDelete("{codpostal}")]
        public async Task<IActionResult> DeleteCodpostal(string codpostal)
        {
            if (_context.Codpostals == null)
            {
                return NotFound();
            }

            var codpostalEntity = await _context.Codpostals.FindAsync(codpostal);
            if (codpostalEntity == null)
            {
                return NotFound();
            }

            _context.Codpostals.Remove(codpostalEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodpostalExists(string codpostal)
        {
            return (_context.Codpostals?.Any(e => e.codpostal1 == codpostal)).GetValueOrDefault();
        }
    }
}