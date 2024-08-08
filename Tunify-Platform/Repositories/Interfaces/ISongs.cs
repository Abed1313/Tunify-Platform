using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongs
    {
        Task<Songs> CreateSongs(Songs songs);
        Task<List<Songs>> GetAllSongs();
        Task<Songs> GetSongsById(int SongsId);
        Task<Songs> UpdateSongs(int SongsId, Songs songs);
        Task DeleteSongs(int SongsId);
    }
}
