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
    public class FundosController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public FundosController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Fundos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetFundos()
        {
            if (_context.Fundos == null)
            {
                return NotFound();
            }

            return await _context.Fundos
                .Select(f => new
                {
                    f.idfundo,
                    f.nome,
                    f.montante,
                    f.taxajuro,
                    idativofk = f.idativoNavigation.idativo
                })
                .ToListAsync();
        }

        // GET: api/Fundos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fundos>> GetFundo(Guid id)
        {
            if (_context.Fundos == null)
            {
                return NotFound();
            }

            var fundo = await _context.Fundos.FindAsync(id);

            if (fundo == null)
            {
                return NotFound();
            }

            return fundo;
        }

        // PUT: api/Fundos/5
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundo(Guid id, Fundos fundo)
        {
            if (id != fundo.idfundo)
            {
                return BadRequest();
            }

            _context.Entry(fundo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundoExists(id))
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

        // POST: api/Fundos
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fundos>> PostFundo(Fundos fundo)
        {
            if (_context.Fundos == null)
            {
                return Problem("Entity set 'ES2DbContext.Fundos' is null.");
            }

            _context.Fundos.Add(fundo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundo", new { id = fundo.idfundo }, fundo);
        }

        // DELETE: api/Fundos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundo(Guid id)
        {
            if (_context.Fundos == null)
            {
                return NotFound();
            }

            var fundo = await _context.Fundos.FindAsync(id);
            if (fundo == null)
            {
                return NotFound();
            }

            _context.Fundos.Remove(fundo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FundoExists(Guid id)
        {
            return (_context.Fundos?.Any(e => e.idfundo == id)).GetValueOrDefault();
        }
    }
}

