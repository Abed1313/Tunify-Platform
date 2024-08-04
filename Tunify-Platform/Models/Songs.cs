namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int SongsID { get; set; } // Primary key
        public string Title { get; set; }
        public int ArtistID { get; set; } // Foreign key
        public Artists Artists { get; set; }
        public int AlbumID { get; set; } // Foreign key
        public Albums Albums { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }
    }
}
