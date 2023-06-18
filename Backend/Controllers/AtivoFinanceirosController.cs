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
    public class AtivofinanceirosController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public AtivofinanceirosController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Ativofinanceiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ativofinanceiros>>> GetAtivofinanceiros()
        {
            if (_context.Ativofinanceiros == null)
            {
                return NotFound();
            }
            else
            {
                Console.WriteLine(_context.Ativofinanceiros);
            }

            return await _context.Ativofinanceiros.ToListAsync();
        }

        // GET: api/Ativofinanceiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ativofinanceiros>> GetAtivofinanceiro(Guid id)
        {
            if (_context.Ativofinanceiros == null)
            {
                return NotFound();
            }

            var ativofinanceiro = await _context.Ativofinanceiros.FindAsync(id);

            if (ativofinanceiro == null)
            {
                return NotFound();
            }

            return ativofinanceiro;
        }

        // PUT: api/Ativofinanceiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtivofinanceiro(Guid id, Ativofinanceiros ativofinanceiro)
        {
            if (id != ativofinanceiro.idativo)
            {
                return BadRequest();
            }

            _context.Entry(ativofinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtivofinanceiroExists(id))
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

        // POST: api/Ativofinanceiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ativofinanceiros>> PostAtivofinanceiro(Ativofinanceiros ativofinanceiro)
        {
            if (_context.Ativofinanceiros == null)
            {
                return Problem("Entity set 'ES2DbContext.Ativofinanceiros' is null.");
            }

            _context.Ativofinanceiros.Add(ativofinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtivofinanceiro", new { id = ativofinanceiro.idativo }, ativofinanceiro);
        }

        // DELETE: api/Ativofinanceiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivofinanceiro(Guid id)
        {
            if (_context.Ativofinanceiros == null)
            {
                return NotFound();
            }

            var ativofinanceiro = await _context.Ativofinanceiros.FindAsync(id);
            if (ativofinanceiro == null)
            {
                return NotFound();
            }

            _context.Ativofinanceiros.Remove(ativofinanceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtivofinanceiroExists(Guid id)
        {
            return (_context.Ativofinanceiros?.Any(e => e.idativo == id)).GetValueOrDefault();
        }
    }
}