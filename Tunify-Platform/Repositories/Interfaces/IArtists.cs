using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<Artists> CreateArtists(Artists artists);
        Task<List<Artists>> GetAllArtists();
        Task<Artists> GetArtistsById(int ArtistsID);
        Task<Artists> UpdateArtists(int ArtistsID, Artists artists);
        Task DeleteArtists(int ArtistsID);
    }
}
