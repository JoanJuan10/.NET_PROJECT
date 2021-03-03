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
    public class OrganigsController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public OrganigsController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/Organigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organig>>> GetOrganig()
        {
            return await _context.Organig.ToListAsync();
        }

        // GET: api/Organigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organig>> GetOrganig(string id)
        {
            var organig = await _context.Organig.FindAsync(id);

            if (organig == null)
            {
                return NotFound();
            }

            return organig;
        }

        // PUT: api/Organigs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutOrganig(string id, Organig organig)
        {
            if (id != organig.IdOrganig)
            {
                return BadRequest();
            }

            _context.Entry(organig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganigExists(id))
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

        // POST: api/Organigs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organig>> PostOrganig(Organig organig)
        {
            _context.Organig.Add(organig);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrganigExists(organig.IdOrganig))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrganig", new { id = organig.IdOrganig }, organig);
        }

        // DELETE: api/Organigs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organig>> DeleteOrganig(string id)
        {
            var organig = await _context.Organig.FindAsync(id);
            if (organig == null)
            {
                return NotFound();
            }

            _context.Organig.Remove(organig);
            await _context.SaveChangesAsync();

            return organig;
        }

        private bool OrganigExists(string id)
        {
            return _context.Organig.Any(e => e.IdOrganig == id);
        }*/
    }
}
