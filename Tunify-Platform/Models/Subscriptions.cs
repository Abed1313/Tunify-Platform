namespace Tunify_Platform.Models
{
    public class Subscriptions
    {
        public int SubscriptionsID { get; set; } // Primary key
        public string SubscriptionType { get; set; }
        public decimal Price { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
