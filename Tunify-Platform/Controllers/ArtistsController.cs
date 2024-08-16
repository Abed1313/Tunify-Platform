using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform.data;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtists _artists;

        public ArtistsController(IArtists context)
        {
            _artists = context;
        }

        // GET: api/Artists
        [Route("/Artest/GetAllArtest")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artists>>> GetArtists()
        {
          return await _artists.GetAllArtists();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtists(int id)
        {
         return await _artists.GetArtistsById(id);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(int id, Artists artists)
        {
            var updateAretest = await _artists.UpdateArtists(id, artists);
            return Ok(updateAretest);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        {
          var newArtest = await _artists.CreateArtists(artists);
            return Ok(newArtest);
        }

        // DELETE: api/Artists/5n 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtists(int id)
        {
           var deleteArtest = _artists.DeleteArtists(id);
            return Ok(deleteArtest);
        }
        [HttpGet("{id}/allSongsArtest")]
        public async Task<ActionResult<List<Songs>>> GetSongsForArtiste(int id)
        {
            var Song = await _artists.GetSongsForArtiste(id);
            return Ok(Song);
        }
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<Songs> AddSongToArtist(int artistId, int songId)
        {
            var Song = await _artists.AddSongToArtist(artistId, songId);
            return Song;
        }
    }
}
