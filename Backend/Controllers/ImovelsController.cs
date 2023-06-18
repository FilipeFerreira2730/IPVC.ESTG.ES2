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
    public class ImovelsController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public ImovelsController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Imoveis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetImoveis()
        {
            if (_context.Imovels == null)
            {
                return NotFound();
            }

            return await _context
                .Imovels.Select(i => new
                {
                    i.idimovel,
                    i.nome,
                    i.valorrenda,
                    i.valorcondo,
                    i.valoresti,
                    i.rua,
                    i.nporta,
                    i.codpostal,
                    idativofk = i.idativoNavigation.idativo,
                })
                .ToListAsync();
        }

        // GET: api/Imoveis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imovels>> GetImovel(Guid id)
        {
            if (_context.Imovels == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovels.FindAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            return imovel;
        }

        // PUT: api/Imoveis/5
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImovel(Guid id, Imovels imovel)
        {
            if (id != imovel.idimovel)
            {
                return BadRequest();
            }

            _context.Entry(imovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImovelExists(id))
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

        // POST: api/Imoveis
        // Para proteção contra ataques de overposting, veja https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imovels>> PostImovel(Imovels imovel)
        {
            if (_context.Imovels == null)
            {
                return Problem("Entity set 'ES2DbContext.Imovels' is null.");
            }

            _context.Imovels.Add(imovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImovel", new { id = imovel.idimovel }, imovel);
        }

        // DELETE: api/Imoveis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImovel(Guid id)
        {
            if (_context.Imovels == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovels.FindAsync(id);
            if (imovel == null){
                return NotFound();
            }
            _context.Imovels.Remove(imovel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImovelExists(Guid id)
        {
            return (_context.Imovels?.Any(e => e.idimovel == id)).GetValueOrDefault();
        }
    }
}