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
    public class VideoJuegosController : ControllerBase
    {
        private readonly dbContext _context;

        public VideoJuegosController(dbContext context)
        {
            _context = context;
        }

        // GET: api/VideoJuegos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoJuego>>> GetVideoJuego()
        {
            var videoJuego = await _context.VideoJuegos
       .Include(e => e.Distribuidor)
       .ToListAsync();

            return videoJuego;
        }

        // GET: api/VideoJuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoJuego>> GetVideoJuego(int id)
        {
            var videoJuego = await _context.VideoJuegos.
        Include(e => e.Distribuidor).
        Where(e => e.Id == id).
        FirstOrDefaultAsync();

            if (videoJuego == null)
            {
                return NotFound();
            }

            return videoJuego;
        }

        // PUT: api/VideoJuegos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoJuego(int id, VideoJuego videoJuego)
        {
            if (id != videoJuego.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoJuego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoJuegoExists(id))
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

        // POST: api/VideoJuegos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoJuego>> PostVideoJuego(VideoJuego videoJuego)
        {
            _context.VideoJuegos.Add(videoJuego);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoJuego", new { id = videoJuego.Id }, videoJuego);
        }

        // DELETE: api/VideoJuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoJuego(int id)
        {
            var videoJuego = await _context.VideoJuegos.FindAsync(id);
            if (videoJuego == null)
            {
                return NotFound();
            }

            _context.VideoJuegos.Remove(videoJuego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoJuegoExists(int id)
        {
            return _context.VideoJuegos.Any(e => e.Id == id);
        }
    }
}
