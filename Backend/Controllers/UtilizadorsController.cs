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
    [Route("api/[controller]/")] 
    [ApiController]
    public class UtilizadorsController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public UtilizadorsController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Utilizadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUtilizadors()
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            return await _context
                .Utilizadors.Select(u => new
                {
                    u.IdUtilizador,
                    u.Nome,
                    u.nif,
                    u.ncc,
                    u.rua,
                    u.n_porta,
                    u.username,
                    u.pass,
                    u.codpostal,
                    u.tipoutilizador,
                    Ativofinanceiros = u.Ativofinanceiros.Select(a => new
                    {
                        a.idativo,
                        a.datainicio,
                        a.duracao,
                        a.taxaimposto,
                        a.idcliente
                    })
                }).ToListAsync();
        }

        // GET: api/Utilizadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizadors>> GetUtilizador(Guid id)
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        // PUT: api/Utilizadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(Guid id, Utilizadors utilizador)
        {
            if (id != utilizador.IdUtilizador)
            {
                return BadRequest();
            }

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
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

        // POST: api/Utilizadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilizadors>> PostUtilizador(Utilizadors utilizador)
        {
            if (_context.Utilizadors == null)
            {
                return Problem("Entity set 'ES2DbContext.Utilizadors' is null.");
            }

            _context.Utilizadors.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { id = utilizador.IdUtilizador }, utilizador);
        }

        // DELETE: api/Utilizadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizador(Guid id)
        {
            if (_context.Utilizadors == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadors.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizadors.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizadorExists(Guid id)
        {
            return (_context.Utilizadors?.Any(e => e.IdUtilizador == id)).GetValueOrDefault();
        }
    }
}