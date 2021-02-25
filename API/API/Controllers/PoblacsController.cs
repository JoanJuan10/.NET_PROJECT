using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoblacsController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public PoblacsController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/Poblacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poblac>>> GetPoblac()
        {
            return await _context.Poblac.ToListAsync();
        }

        // GET: api/Poblacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poblac>> GetPoblac(string id)
        {
            var poblac = await _context.Poblac.FindAsync(id);

            if (poblac == null)
            {
                return NotFound();
            }

            return poblac;
        }

        // PUT: api/Poblacs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoblac(string id, Poblac poblac)
        {
            if (id != poblac.IdProvincia)
            {
                return BadRequest();
            }

            _context.Entry(poblac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoblacExists(id))
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

        // POST: api/Poblacs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Poblac>> PostPoblac(Poblac poblac)
        {
            _context.Poblac.Add(poblac);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PoblacExists(poblac.IdProvincia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPoblac", new { id = poblac.IdProvincia }, poblac);
        }

        // DELETE: api/Poblacs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poblac>> DeletePoblac(string id)
        {
            var poblac = await _context.Poblac.FindAsync(id);
            if (poblac == null)
            {
                return NotFound();
            }

            _context.Poblac.Remove(poblac);
            await _context.SaveChangesAsync();

            return poblac;
        }

        private bool PoblacExists(string id)
        {
            return _context.Poblac.Any(e => e.IdProvincia == id);
        }
    }
}
