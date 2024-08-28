using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options)
        {

        }

        public DbSet<Albums> Albums { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSongs> PlaylistsSongs { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users to Playlist (1:Many)
            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            // Playlists to PlaylistSongs (1:Many)
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistID)
                .OnDelete(DeleteBehavior.NoAction);

            // Songs to PlaylistSongs (1:Many)
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Songs)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongID)
                .OnDelete(DeleteBehavior.NoAction);

            // Artists to Songs (1:Many)
            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Artists)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistID)
                .OnDelete(DeleteBehavior.NoAction);

            // Albums to Songs (1:Many)
            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Albums)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumID)
                .OnDelete(DeleteBehavior.Cascade);

            // Subscriptions to Users (1:Many)
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Subscriptions)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SubscriptionID)
                .OnDelete(DeleteBehavior.NoAction);

            // Artists to Albums (1:Many)
            modelBuilder.Entity<Albums>()
                .HasOne(a => a.Artists)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Subscriptions>().HasData(
         new Subscriptions { SubscriptionsID = 1, SubscriptionType = "Free", Price = 0.00m },
         new Subscriptions { SubscriptionsID = 2, SubscriptionType = "Basic", Price = 9.99m },
         new Subscriptions { SubscriptionsID = 3, SubscriptionType = "Standard", Price = 14.99m },
         new Subscriptions { SubscriptionsID = 4, SubscriptionType = "Premium", Price = 19.99m },
         new Subscriptions { SubscriptionsID = 5, SubscriptionType = "Family", Price = 29.99m }
     );

            modelBuilder.Entity<Users>().HasData(
        new Users { UsersID = 1, Username = "Abed", Email = "Abed@gmail.com", JoinDate = new DateTime(2023, 1, 1), SubscriptionID = 1 },
        new Users { UsersID = 2, Username = "Britta", Email = "Britta@gmail.com", JoinDate = new DateTime(2023, 2, 1), SubscriptionID = 2 },
        new Users { UsersID = 3, Username = "Shirley", Email = "Shirley@gmail.com", JoinDate = new DateTime(2023, 3, 1), SubscriptionID = 3 },
        new Users { UsersID = 4, Username = "Annie", Email = "Annie@gmail.com", JoinDate = new DateTime(2023, 4, 1), SubscriptionID = 4 },
        new Users { UsersID = 5, Username = "Troy", Email = "Troy@gmail.com", JoinDate = new DateTime(2023, 5, 1), SubscriptionID = 5 }
    );

            modelBuilder.Entity<Playlist>().HasData(
        new Playlist { PlaylistID = 1, UserID = 1, PlaylistName = "Chill Vibes", CreatedDate = new DateTime(2023, 1, 5) },
        new Playlist { PlaylistID = 2, UserID = 2, PlaylistName = "Workout Hits", CreatedDate = new DateTime(2023, 2, 10) },
        new Playlist { PlaylistID = 3, UserID = 3, PlaylistName = "Road Trip", CreatedDate = new DateTime(2023, 3, 15) },
        new Playlist { PlaylistID = 4, UserID = 4, PlaylistName = "Study Session", CreatedDate = new DateTime(2023, 4, 20) },
        new Playlist { PlaylistID = 5, UserID = 5, PlaylistName = "Party Time", CreatedDate = new DateTime(2023, 5, 25) }
    );
            // Seeding Artists
            modelBuilder.Entity<Artists>().HasData(
        new Artists { ArtistsID = 1, Name = "Artist One", Bio = "Bio of Artist One" },
        new Artists { ArtistsID = 2, Name = "Artist Two", Bio = "Bio of Artist Two" },
        new Artists { ArtistsID = 3, Name = "Artist Three", Bio = "Bio of Artist Three" }
    );

            // Seeding Albums
            modelBuilder.Entity<Albums>().HasData(
                new Albums { AlbumsID = 1, AlbumName = "Album One", ReleaseDate = new DateTime(2023, 1, 10), ArtistID = 1 },
                new Albums { AlbumsID = 2, AlbumName = "Album Two", ReleaseDate = new DateTime(2023, 2, 15), ArtistID = 2 },
                new Albums { AlbumsID = 3, AlbumName = "Album Three", ReleaseDate = new DateTime(2023, 3, 20), ArtistID = 3 }
            );

            modelBuilder.Entity<Songs>().HasData(
        new Songs { SongsID = 1, Title = "Song One", ArtistID = 1, AlbumID = 1, Duration = new TimeSpan(0, 3, 45), Genre = "Pop" },
        new Songs { SongsID = 2, Title = "Song Two", ArtistID = 2, AlbumID = 2, Duration = new TimeSpan(0, 4, 12), Genre = "Rock" },
        new Songs { SongsID = 3, Title = "Song Three", ArtistID = 3, AlbumID = 3, Duration = new TimeSpan(0, 2, 58), Genre = "Jazz" },
        new Songs { SongsID = 4, Title = "Song Four", ArtistID = 1, AlbumID = 1, Duration = new TimeSpan(0, 3, 22), Genre = "Pop" },
        new Songs { SongsID = 5, Title = "Song Five", ArtistID = 2, AlbumID = 2, Duration = new TimeSpan(0, 5, 30), Genre = "Rock" }
    );
            modelBuilder.Entity<PlaylistSongs>().HasData(
        new PlaylistSongs { PlaylistSongsID = 1, PlaylistID = 1, SongID = 1 },
        new PlaylistSongs { PlaylistSongsID = 2, PlaylistID = 1, SongID = 2 },
        new PlaylistSongs { PlaylistSongsID = 3, PlaylistID = 2, SongID = 3 },
        new PlaylistSongs { PlaylistSongsID = 4, PlaylistID = 3, SongID = 4 },
        new PlaylistSongs { PlaylistSongsID = 5, PlaylistID = 4, SongID = 5 },
        new PlaylistSongs { PlaylistSongsID = 6, PlaylistID = 5, SongID = 1 },
        new PlaylistSongs { PlaylistSongsID = 7, PlaylistID = 5, SongID = 3 }
);
            seedRole(modelBuilder, "Admin","Delete","Update");
            seedRole(modelBuilder, "User");

            base.OnModelCreating(modelBuilder);
        }

        private void seedRole(ModelBuilder modelBuilder, string roleName, params string[] claims)
        {
            var roleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });

            var roleClaims = claims.Select(claim => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().ToString().GetHashCode(), // generates a unique ID for each claim
                RoleId = roleId,
                ClaimType = "Permission", // or any custom claim type
                ClaimValue = claim
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
