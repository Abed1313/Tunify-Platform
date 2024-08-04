namespace Tunify_Platform.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; } // Primary key
        public int UserID { get; set; } // Foreign key
        public Users User { get; set; }
        public string PlaylistName { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<PlaylistSongs> PlaylistSongs { get; set; }


        
    }
}
