using Microsoft.EntityFrameworkCore;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Servises
{
    public class PlaylistServises : IPlaylist
    {
        private readonly TunifyDbContext _context;

        public PlaylistServises(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlist> CreatePlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task DeletePlaylist(int PlaylistID)
        {
            var playlist = await GetPlaylistById(PlaylistID);
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlist>> GetAllPlaylist()
        {
           var allPlaylist = await _context.Playlists.ToListAsync();
            return allPlaylist;
        }

        public async Task<Playlist> GetPlaylistById(int PlaylistID)
        {
            var playlistById = await _context.Playlists.FindAsync(PlaylistID);
            return playlistById;
        }

        public async Task<Playlist> UpdatePlaylist(int PlaylistID, Playlist playlist)
        {
            var exeistingPlaylist = await _context.Playlists.FindAsync(PlaylistID);
            exeistingPlaylist = playlist;
           await _context.SaveChangesAsync();
            return exeistingPlaylist;

        }
    }
}
