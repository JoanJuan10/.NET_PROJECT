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
    public class TProvisController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public TProvisController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/TProvis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProvis>>> GetTProvis()
        {
            return await _context.TProvis.ToListAsync();
        }

        // GET: api/TProvis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TProvis>> GetTProvis(string id)
        {
            var tProvis = await _context.TProvis.FindAsync(id);

            if (tProvis == null)
            {
                return NotFound();
            }

            return tProvis;
        }

        // PUT: api/TProvis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTProvis(string id, TProvis tProvis)
        {
            if (id != tProvis.TProvis1)
            {
                return BadRequest();
            }

            _context.Entry(tProvis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TProvisExists(id))
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

        // POST: api/TProvis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TProvis>> PostTProvis(TProvis tProvis)
        {
            _context.TProvis.Add(tProvis);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TProvisExists(tProvis.TProvis1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTProvis", new { id = tProvis.TProvis1 }, tProvis);
        }

        // DELETE: api/TProvis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TProvis>> DeleteTProvis(string id)
        {
            var tProvis = await _context.TProvis.FindAsync(id);
            if (tProvis == null)
            {
                return NotFound();
            }

            _context.TProvis.Remove(tProvis);
            await _context.SaveChangesAsync();

            return tProvis;
        }

        private bool TProvisExists(string id)
        {
            return _context.TProvis.Any(e => e.TProvis1 == id);
        }
    }
}
