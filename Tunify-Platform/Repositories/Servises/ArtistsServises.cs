using Microsoft.EntityFrameworkCore;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Servises
{
    public class ArtistsServises : IArtists
    {
        private readonly TunifyDbContext _context;

        public ArtistsServises(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Artists> CreateArtists(Artists artists)
        {
            _context.Artists.Add(artists);
            await _context.SaveChangesAsync();
            return artists;
        }

        public async Task DeleteArtists(int ArtistsID)
        {
            var getArtest = await GetArtistsById(ArtistsID);
            _context.Artists.Remove(getArtest);
            await _context.SaveChangesAsync();
        }

        public Task<List<Artists>> GetAllArtists()
        {
            var artists = _context.Artists.ToListAsync();
            return artists;
        }

        public async Task<Artists> GetArtistsById(int ArtistsID)
        {
            var artestById = await _context.Artists.FindAsync(ArtistsID);
            return artestById;
        }

        public async Task<Artists> UpdateArtists(int ArtistsID, Artists artists)
        {
            var ecsistingartest = await _context.Artists.FindAsync(ArtistsID);
            ecsistingartest = artists;
            await _context.SaveChangesAsync();
            return artists;
        }
        public async Task<List<Songs>> GetSongsForArtiste(int artestID)
        {
            var artestSongsVar = await _context.Songs
                .Where(pl => pl.ArtistID == artestID)
                .ToListAsync();

            return artestSongsVar;
        }
        public async Task<Songs> AddSongToArtist(int artistId, int songId)
        {
            var song = await _context.Songs.FindAsync(songId);
            if (song != null)
            {
                song.ArtistID = artistId;
                _context.Entry(song).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            var aaa = _context.Songs.Where(a => a.ArtistID == artistId).FirstOrDefault();
            return aaa;
        }
    }
}
