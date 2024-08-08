using Microsoft.EntityFrameworkCore;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Servises
{
    public class SongsServises : ISongs
    {
        private readonly TunifyDbContext _context;

        public SongsServises(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Songs> CreateSongs(Songs songs)
        {
            _context.Songs.Add(songs);
           await _context.SaveChangesAsync();
            return songs;
        }

        public async Task DeleteSongs(int SongsId)
        {
            var getSonges = await GetSongsById(SongsId);
            _context.Songs.Remove(getSonges);
            await _context.SaveChangesAsync();      
        }

        public async Task<List<Songs>> GetAllSongs()
        {
            var allSongs = await _context.Songs.ToListAsync();
            return allSongs;
        }

        public async Task<Songs> GetSongsById(int SongsId)
        {
            var songsById = await _context.Songs.FindAsync(SongsId);
            return songsById;
        }

        public async Task<Songs> UpdateSongs(int SongsId, Songs songs)
        {
            var exeistingSongs = await _context.Songs.FindAsync(SongsId);
            exeistingSongs = songs;
            await _context.SaveChangesAsync();
            return exeistingSongs;


        }
    }
}
