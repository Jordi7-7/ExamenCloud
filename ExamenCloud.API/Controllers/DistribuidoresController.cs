using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenCloud.Entidades;

namespace ExamenCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidoresController : ControllerBase
    {
        private readonly dbContext _context;

        public DistribuidoresController(dbContext context)
        {
            _context = context;
        }

        // GET: api/Distribuidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribuidor>>> GetDistribuidor()
        {
            return await _context.Distribuidores.ToListAsync();
        }

        // GET: api/Distribuidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distribuidor>> GetDistribuidor(int id)
        {
            var distribuidor = await _context.Distribuidores.FindAsync(id);


            if (distribuidor == null)
            {
                return NotFound();
            }

            return distribuidor;
        }

        // PUT: api/Distribuidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribuidor(int id, Distribuidor distribuidor)
        {
            if (id != distribuidor.Id)
            {
                return BadRequest();
            }

            _context.Entry(distribuidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistribuidorExists(id))
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

        // POST: api/Distribuidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Distribuidor>> PostDistribuidor(Distribuidor distribuidor)
        {
            _context.Distribuidores.Add(distribuidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistribuidor", new { id = distribuidor.Id }, distribuidor);
        }

        // DELETE: api/Distribuidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribuidor(int id)
        {
            var distribuidor = await _context.Distribuidores.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            _context.Distribuidores.Remove(distribuidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistribuidorExists(int id)
        {
            return _context.Distribuidores.Any(e => e.Id == id);
        }
    }
}
