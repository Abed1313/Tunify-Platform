namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsID { get; set; } // Primary key
        public int PlaylistID { get; set; } // Foreign key
        public Playlist Playlist { get; set; }
        public int SongID { get; set; } // Foreign key
        public Songs Songs { get; set; }
    }
}
