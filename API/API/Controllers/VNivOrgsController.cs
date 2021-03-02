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
    public class VNivOrgsController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public VNivOrgsController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/VNivOrgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNivOrg>>> GetVNivOrg()
        {
            return await _context.VNivOrg.ToListAsync();
        }

        // GET: api/VNivOrgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNivOrg>> GetVNivOrg(int id)
        {
            var vNivOrg = await _context.VNivOrg.FindAsync(id);

            if (vNivOrg == null)
            {
                return NotFound();
            }

            return vNivOrg;
        }

        // PUT: api/VNivOrgs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVNivOrg(int id, VNivOrg vNivOrg)
        {
            if (id != vNivOrg.Id)
            {
                return BadRequest();
            }

            _context.Entry(vNivOrg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VNivOrgExists(id))
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

        // POST: api/VNivOrgs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VNivOrg>> PostVNivOrg(VNivOrg vNivOrg)
        {
            _context.VNivOrg.Add(vNivOrg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVNivOrg", new { id = vNivOrg.Id }, vNivOrg);
        }

        // DELETE: api/VNivOrgs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VNivOrg>> DeleteVNivOrg(int id)
        {
            var vNivOrg = await _context.VNivOrg.FindAsync(id);
            if (vNivOrg == null)
            {
                return NotFound();
            }

            _context.VNivOrg.Remove(vNivOrg);
            await _context.SaveChangesAsync();

            return vNivOrg;
        }

        private bool VNivOrgExists(int id)
        {
            return _context.VNivOrg.Any(e => e.Id == id);
        }
    }
}
