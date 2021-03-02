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
    public class SiglasController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public SiglasController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/Siglas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siglas>>> GetSiglas()
        {
            return await _context.Siglas.ToListAsync();
        }

        // GET: api/Siglas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Siglas>> GetSiglas(string id)
        {
            var siglas = await _context.Siglas.FindAsync(id);

            if (siglas == null)
            {
                return NotFound();
            }

            return siglas;
        }

        // PUT: api/Siglas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiglas(string id, Siglas siglas)
        {
            if (id != siglas.Siglas1)
            {
                return BadRequest();
            }

            _context.Entry(siglas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiglasExists(id))
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

        // POST: api/Siglas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Siglas>> PostSiglas(Siglas siglas)
        {
            _context.Siglas.Add(siglas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SiglasExists(siglas.Siglas1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSiglas", new { id = siglas.Siglas1 }, siglas);
        }

        // DELETE: api/Siglas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Siglas>> DeleteSiglas(string id)
        {
            var siglas = await _context.Siglas.FindAsync(id);
            if (siglas == null)
            {
                return NotFound();
            }

            _context.Siglas.Remove(siglas);
            await _context.SaveChangesAsync();

            return siglas;
        }

        private bool SiglasExists(string id)
        {
            return _context.Siglas.Any(e => e.Siglas1 == id);
        }
    }
}
