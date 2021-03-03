using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EscalasController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public EscalasController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/Escalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escala>>> GetEscala()
        {
            return await _context.Escala.ToListAsync();
        }

        // GET: api/Escalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escala>> GetEscala(string id)
        {
            var escala = await _context.Escala.FindAsync(id);

            if (escala == null)
            {
                return NotFound();
            }

            return escala;
        }

        // PUT: api/Escalas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutEscala(string id, Escala escala)
        {
            if (id != escala.IdEscala)
            {
                return BadRequest();
            }

            _context.Entry(escala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscalaExists(id))
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

        // POST: api/Escalas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Escala>> PostEscala(Escala escala)
        {
            _context.Escala.Add(escala);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EscalaExists(escala.IdEscala))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEscala", new { id = escala.IdEscala }, escala);
        }

        // DELETE: api/Escalas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escala>> DeleteEscala(string id)
        {
            var escala = await _context.Escala.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }

            _context.Escala.Remove(escala);
            await _context.SaveChangesAsync();

            return escala;
        }

        private bool EscalaExists(string id)
        {
            return _context.Escala.Any(e => e.IdEscala == id);
        }*/
    }
}
