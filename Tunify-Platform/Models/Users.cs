namespace Tunify_Platform.Models
{
    public class Users
    {
        public int UsersID { get; set; } // Primary key
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public int SubscriptionID { get; set; } // Foreign key
        public Subscriptions Subscriptions { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
    }
}
