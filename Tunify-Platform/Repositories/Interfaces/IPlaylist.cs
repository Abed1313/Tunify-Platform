using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlaylist
    {
        Task<Playlist> CreatePlaylist(Playlist playlist);
        Task<List<Playlist>> GetAllPlaylist();
        Task<Playlist> GetPlaylistById(int PlaylistID);
        Task<Playlist> UpdatePlaylist(int PlaylistID, Playlist playlist);
        Task DeletePlaylist(int PlaylistID);
    }
}
