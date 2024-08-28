using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.data;
using Microsoft.AspNetCore.Authorization;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly TunifyDbContext _context;

        public AlbumsController(TunifyDbContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Albums>>> GetAlbums()
        {
          if (_context.Albums == null)
          {
              return NotFound();
          }
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Albums>> GetAlbums(int id)
        {
          if (_context.Albums == null)
          {
              return NotFound();
          }
            var albums = await _context.Albums.FindAsync(id);

            if (albums == null)
            {
                return NotFound();
            }

            return albums;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbums(int id, Albums albums)
        {
            if (id != albums.AlbumsID)
            {
                return BadRequest();
            }

            _context.Entry(albums).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumsExists(id))
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

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Albums>> PostAlbums(Albums albums)
        {
          if (_context.Albums == null)
          {
              return Problem("Entity set 'TunifyDbContext.Albums'  is null.");
          }
            _context.Albums.Add(albums);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbums", new { id = albums.AlbumsID }, albums);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbums(int id)
        {
            if (_context.Albums == null)
            {
                return NotFound();
            }
            var albums = await _context.Albums.FindAsync(id);
            if (albums == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(albums);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumsExists(int id)
        {
            return (_context.Albums?.Any(e => e.AlbumsID == id)).GetValueOrDefault();
        }
    }
}
