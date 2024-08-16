using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.data;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly TunifyDbContext _context;

        public PlaylistSongsController(TunifyDbContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistSongs>>> GetPlaylistsSongs()
        {
          if (_context.PlaylistsSongs == null)
          {
              return NotFound();
          }
            return await _context.PlaylistsSongs.ToListAsync();
        }

        // GET: api/PlaylistSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistSongs>> GetPlaylistSongs(int id)
        {
          if (_context.PlaylistsSongs == null)
          {
              return NotFound();
          }
            var playlistSongs = await _context.PlaylistsSongs.FindAsync(id);

            if (playlistSongs == null)
            {
                return NotFound();
            }

            return playlistSongs;
        }

        // PUT: api/PlaylistSongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistSongs(int id, PlaylistSongs playlistSongs)
        {
            if (id != playlistSongs.PlaylistSongsID)
            {
                return BadRequest();
            }

            _context.Entry(playlistSongs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistSongsExists(id))
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

        // POST: api/PlaylistSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaylistSongs>> PostPlaylistSongs(PlaylistSongs playlistSongs)
        {
          if (_context.PlaylistsSongs == null)
          {
              return Problem("Entity set 'TunifyDbContext.PlaylistsSongs'  is null.");
          }
            _context.PlaylistsSongs.Add(playlistSongs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylistSongs", new { id = playlistSongs.PlaylistSongsID }, playlistSongs);
        }

        // DELETE: api/PlaylistSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylistSongs(int id)
        {
            if (_context.PlaylistsSongs == null)
            {
                return NotFound();
            }
            var playlistSongs = await _context.PlaylistsSongs.FindAsync(id);
            if (playlistSongs == null)
            {
                return NotFound();
            }

            _context.PlaylistsSongs.Remove(playlistSongs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistSongsExists(int id)
        {
            return (_context.PlaylistsSongs?.Any(e => e.PlaylistSongsID == id)).GetValueOrDefault();
        }

    }
}
