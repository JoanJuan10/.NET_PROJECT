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
    public class ClasePersController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public ClasePersController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/ClasePers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasePer>>> GetClasePer()
        {
            return await _context.ClasePer.ToListAsync();
        }

        // GET: api/ClasePers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasePer>> GetClasePer(string id)
        {
            var clasePer = await _context.ClasePer.FindAsync(id);

            if (clasePer == null)
            {
                return NotFound();
            }

            return clasePer;
        }

        // PUT: api/ClasePers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasePer(string id, ClasePer clasePer)
        {
            if (id != clasePer.IdClasePer)
            {
                return BadRequest();
            }

            _context.Entry(clasePer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasePerExists(id))
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

        // POST: api/ClasePers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClasePer>> PostClasePer(ClasePer clasePer)
        {
            _context.ClasePer.Add(clasePer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClasePerExists(clasePer.IdClasePer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClasePer", new { id = clasePer.IdClasePer }, clasePer);
        }

        // DELETE: api/ClasePers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClasePer>> DeleteClasePer(string id)
        {
            var clasePer = await _context.ClasePer.FindAsync(id);
            if (clasePer == null)
            {
                return NotFound();
            }

            _context.ClasePer.Remove(clasePer);
            await _context.SaveChangesAsync();

            return clasePer;
        }

        private bool ClasePerExists(string id)
        {
            return _context.ClasePer.Any(e => e.IdClasePer == id);
        }
    }
}
