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
    public class VTrabajadoresController : ControllerBase
    {
        private readonly BootcampDBContext _context;

        public VTrabajadoresController(BootcampDBContext context)
        {
            _context = context;
        }

        // GET: api/VTrabajadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VTrabajadores>>> GetVTrabajadores()
        {
            return await _context.VTrabajadores.ToListAsync();
        }

        // GET: api/VTrabajadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VTrabajadores>> GetVTrabajadores(int id)
        {
            var vTrabajadores = await _context.VTrabajadores.FindAsync(id);

            if (vTrabajadores == null)
            {
                return NotFound();
            }

            return vTrabajadores;
        }

        // PUT: api/VTrabajadores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVTrabajadores(int id, VTrabajadores vTrabajadores)
        {
            if (id != vTrabajadores.Id)
            {
                return BadRequest();
            }

            _context.Entry(vTrabajadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VTrabajadoresExists(id))
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

        // POST: api/VTrabajadores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VTrabajadores>> PostVTrabajadores(VTrabajadores vTrabajadores)
        {
            _context.VTrabajadores.Add(vTrabajadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVTrabajadores", new { id = vTrabajadores.Id }, vTrabajadores);
        }

        // DELETE: api/VTrabajadores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VTrabajadores>> DeleteVTrabajadores(int id)
        {
            var vTrabajadores = await _context.VTrabajadores.FindAsync(id);
            if (vTrabajadores == null)
            {
                return NotFound();
            }

            _context.VTrabajadores.Remove(vTrabajadores);
            await _context.SaveChangesAsync();

            return vTrabajadores;
        }

        private bool VTrabajadoresExists(int id)
        {
            return _context.VTrabajadores.Any(e => e.Id == id);
        }
    }
}
