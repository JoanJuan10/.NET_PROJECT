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
    public class SubescalasController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public SubescalasController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/Subescalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subescala>>> GetSubescala()
        {
            return await _context.Subescala.ToListAsync();
        }

        // GET: api/Subescalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subescala>> GetSubescala(string id)
        {
            var subescala = await _context.Subescala.FindAsync(id);

            if (subescala == null)
            {
                return NotFound();
            }

            return subescala;
        }

        // PUT: api/Subescalas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubescala(string id, Subescala subescala)
        {
            if (id != subescala.IdSubescala)
            {
                return BadRequest();
            }

            _context.Entry(subescala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubescalaExists(id))
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

        // POST: api/Subescalas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subescala>> PostSubescala(Subescala subescala)
        {
            _context.Subescala.Add(subescala);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubescalaExists(subescala.IdSubescala))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubescala", new { id = subescala.IdSubescala }, subescala);
        }

        // DELETE: api/Subescalas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subescala>> DeleteSubescala(string id)
        {
            var subescala = await _context.Subescala.FindAsync(id);
            if (subescala == null)
            {
                return NotFound();
            }

            _context.Subescala.Remove(subescala);
            await _context.SaveChangesAsync();

            return subescala;
        }

        private bool SubescalaExists(string id)
        {
            return _context.Subescala.Any(e => e.IdSubescala == id);
        }
    }
}
