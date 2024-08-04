namespace Tunify_Platform.Models
{
    public class Artists
    {
        public int ArtistsID { get; set; } // Primary key
        public string Name { get; set; }
        public string Bio { get; set; }

        public ICollection<Songs> Songs { get; set; }
        public ICollection<Albums> Albums { get; set; }
    }
}
