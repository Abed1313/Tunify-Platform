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
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylist _playlist;

        public PlaylistsController(IPlaylist context)
        {
            _playlist = context;
        }

        // GET: api/Playlists
        [Route("/Playlists/GetAllPlaylists")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
          return await _playlist.GetAllPlaylist();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
          return await _playlist.GetPlaylistById(id);
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            var updatePlaylist = await _playlist.UpdatePlaylist(id,playlist);
            return Ok(updatePlaylist);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            var newPlaylist = await _playlist.CreatePlaylist(playlist);
            return Ok(playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var deletePlaylist = _playlist.DeletePlaylist(id);
            return Ok(deletePlaylist);
        }

        [HttpGet("{id}/allSongs")]
        public async Task<ActionResult<List<Songs>>> GetSongsForPlaylist(int id)
        {
            var Song = await _playlist.GetSongsForPlaylist(id);
            return Ok(Song);
        }

        [HttpPost("playlists/{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var playlist = await _playlist.AddSongToPlaylist(playlistId, songId);
            return Ok(playlist);
        }
    }
}
