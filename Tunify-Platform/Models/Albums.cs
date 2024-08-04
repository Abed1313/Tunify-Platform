namespace Tunify_Platform.Models
{
    public class Albums
    {
        public int AlbumsID { get; set; } // Primary key
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistID { get; set; } // Foreign key
        public Artists Artists { get; set; }

        public ICollection<Songs> Songs { get; set; }
    }
}
