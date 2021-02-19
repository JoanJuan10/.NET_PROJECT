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
    public class SitAdmvsController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public SitAdmvsController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/SitAdmvs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SitAdmv>>> GetSitAdmv()
        {
            return await _context.SitAdmv.ToListAsync();
        }

        // GET: api/SitAdmvs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SitAdmv>> GetSitAdmv(string id)
        {
            var sitAdmv = await _context.SitAdmv.FindAsync(id);

            if (sitAdmv == null)
            {
                return NotFound();
            }

            return sitAdmv;
        }

        // PUT: api/SitAdmvs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitAdmv(string id, SitAdmv sitAdmv)
        {
            if (id != sitAdmv.SitAdmv1)
            {
                return BadRequest();
            }

            _context.Entry(sitAdmv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitAdmvExists(id))
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

        // POST: api/SitAdmvs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SitAdmv>> PostSitAdmv(SitAdmv sitAdmv)
        {
            _context.SitAdmv.Add(sitAdmv);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SitAdmvExists(sitAdmv.SitAdmv1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSitAdmv", new { id = sitAdmv.SitAdmv1 }, sitAdmv);
        }

        // DELETE: api/SitAdmvs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SitAdmv>> DeleteSitAdmv(string id)
        {
            var sitAdmv = await _context.SitAdmv.FindAsync(id);
            if (sitAdmv == null)
            {
                return NotFound();
            }

            _context.SitAdmv.Remove(sitAdmv);
            await _context.SaveChangesAsync();

            return sitAdmv;
        }

        private bool SitAdmvExists(string id)
        {
            return _context.SitAdmv.Any(e => e.SitAdmv1 == id);
        }
    }
}
