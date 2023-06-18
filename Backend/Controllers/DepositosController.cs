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
    public class DepositosController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public DepositosController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Depositos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetDepositos()
        {
            if (_context.Depositos == null)
            {
                return NotFound();
            }

            return await _context.Depositos
                .Select(d => new
                {
                    d.iddeposito,
                    d.banco,
                    d.titulares,
                    d.valor,
                    d.taxajuro,
                    d.nconta,
                    idativofk = d.idativoNavigation.idativo
                })
                .ToListAsync();
        }

        // GET: api/Depositos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depositos>> GetDeposito(Guid id)
        {
            if (_context.Depositos == null)
            {
                return NotFound();
            }

            var deposito = await _context.Depositos.FindAsync(id);

            if (deposito == null)
            {
                return NotFound();
            }

            return deposito;
        }

        // PUT: api/Depositos/5
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeposito(Guid id, Depositos deposito)
        {
            if (id != deposito.iddeposito)
            {
                return BadRequest();
            }

            _context.Entry(deposito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(id))
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

        // POST: api/Depositos
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Depositos>> PostDeposito(Depositos deposito)
        {
            if (_context.Depositos == null)
            {
                return Problem("Entity set 'ES2DbContext.Depositos' is null.");
            }

            _context.Depositos.Add(deposito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposito", new { id = deposito.iddeposito }, deposito);
        }

        // DELETE: api/Depositos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeposito(Guid id)
        {
            if (_context.Depositos == null)
            {
                return NotFound();
            }

            var deposito = await _context.Depositos.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }

            _context.Depositos.Remove(deposito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepositoExists(Guid id)
        {
            return (_context.Depositos?.Any(e => e.iddeposito == id)).GetValueOrDefault();
        }
    }
}