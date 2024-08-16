﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    partial class TunifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.Property<int>("AlbumsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumsID"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumsID");

                    b.HasIndex("ArtistID");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumsID = 1,
                            AlbumName = "Album One",
                            ArtistID = 1,
                            ReleaseDate = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumsID = 2,
                            AlbumName = "Album Two",
                            ArtistID = 2,
                            ReleaseDate = new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AlbumsID = 3,
                            AlbumName = "Album Three",
                            ArtistID = 3,
                            ReleaseDate = new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artists", b =>
                {
                    b.Property<int>("ArtistsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistsID"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistsID");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistsID = 1,
                            Bio = "Bio of Artist One",
                            Name = "Artist One"
                        },
                        new
                        {
                            ArtistsID = 2,
                            Bio = "Bio of Artist Two",
                            Name = "Artist Two"
                        },
                        new
                        {
                            ArtistsID = 3,
                            Bio = "Bio of Artist Three",
                            Name = "Artist Three"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PlaylistID");

                    b.HasIndex("UserID");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            PlaylistID = 1,
                            CreatedDate = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Chill Vibes",
                            UserID = 1
                        },
                        new
                        {
                            PlaylistID = 2,
                            CreatedDate = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Workout Hits",
                            UserID = 2
                        },
                        new
                        {
                            PlaylistID = 3,
                            CreatedDate = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Road Trip",
                            UserID = 3
                        },
                        new
                        {
                            PlaylistID = 4,
                            CreatedDate = new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Study Session",
                            UserID = 4
                        },
                        new
                        {
                            PlaylistID = 5,
                            CreatedDate = new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Party Time",
                            UserID = 5
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistSongsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistSongsID"));

                    b.Property<int>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongsID");

                    b.HasIndex("PlaylistID");

                    b.HasIndex("SongID");

                    b.ToTable("PlaylistsSongs");

                    b.HasData(
                        new
                        {
                            PlaylistSongsID = 1,
                            PlaylistID = 1,
                            SongID = 1
                        },
                        new
                        {
                            PlaylistSongsID = 2,
                            PlaylistID = 1,
                            SongID = 2
                        },
                        new
                        {
                            PlaylistSongsID = 3,
                            PlaylistID = 2,
                            SongID = 3
                        },
                        new
                        {
                            PlaylistSongsID = 4,
                            PlaylistID = 3,
                            SongID = 4
                        },
                        new
                        {
                            PlaylistSongsID = 5,
                            PlaylistID = 4,
                            SongID = 5
                        },
                        new
                        {
                            PlaylistSongsID = 6,
                            PlaylistID = 5,
                            SongID = 1
                        },
                        new
                        {
                            PlaylistSongsID = 7,
                            PlaylistID = 5,
                            SongID = 3
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.Property<int>("SongsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongsID"));

                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongsID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("ArtistID");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongsID = 1,
                            AlbumID = 1,
                            ArtistID = 1,
                            Duration = new TimeSpan(0, 0, 3, 45, 0),
                            Genre = "Pop",
                            Title = "Song One"
                        },
                        new
                        {
                            SongsID = 2,
                            AlbumID = 2,
                            ArtistID = 2,
                            Duration = new TimeSpan(0, 0, 4, 12, 0),
                            Genre = "Rock",
                            Title = "Song Two"
                        },
                        new
                        {
                            SongsID = 3,
                            AlbumID = 3,
                            ArtistID = 3,
                            Duration = new TimeSpan(0, 0, 2, 58, 0),
                            Genre = "Jazz",
                            Title = "Song Three"
                        },
                        new
                        {
                            SongsID = 4,
                            AlbumID = 1,
                            ArtistID = 1,
                            Duration = new TimeSpan(0, 0, 3, 22, 0),
                            Genre = "Pop",
                            Title = "Song Four"
                        },
                        new
                        {
                            SongsID = 5,
                            AlbumID = 2,
                            ArtistID = 2,
                            Duration = new TimeSpan(0, 0, 5, 30, 0),
                            Genre = "Rock",
                            Title = "Song Five"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscriptions", b =>
                {
                    b.Property<int>("SubscriptionsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionsID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionsID");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionsID = 1,
                            Price = 0.00m,
                            SubscriptionType = "Free"
                        },
                        new
                        {
                            SubscriptionsID = 2,
                            Price = 9.99m,
                            SubscriptionType = "Basic"
                        },
                        new
                        {
                            SubscriptionsID = 3,
                            Price = 14.99m,
                            SubscriptionType = "Standard"
                        },
                        new
                        {
                            SubscriptionsID = 4,
                            Price = 19.99m,
                            SubscriptionType = "Premium"
                        },
                        new
                        {
                            SubscriptionsID = 5,
                            Price = 29.99m,
                            SubscriptionType = "Family"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.Property<int>("UsersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersID");

                    b.HasIndex("SubscriptionID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UsersID = 1,
                            Email = "Abed@gmail.com",
                            JoinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 1,
                            Username = "Abed"
                        },
                        new
                        {
                            UsersID = 2,
                            Email = "Britta@gmail.com",
                            JoinDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 2,
                            Username = "Britta"
                        },
                        new
                        {
                            UsersID = 3,
                            Email = "Shirley@gmail.com",
                            JoinDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 3,
                            Username = "Shirley"
                        },
                        new
                        {
                            UsersID = 4,
                            Email = "Annie@gmail.com",
                            JoinDate = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 4,
                            Username = "Annie"
                        },
                        new
                        {
                            UsersID = 5,
                            Email = "Troy@gmail.com",
                            JoinDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubscriptionID = 5,
                            Username = "Troy"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Artists", "Artists")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Users", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Songs", "Songs")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Albums", "Albums")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Artists", "Artists")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Albums");

                    b.Navigation("Artists");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Subscriptions", "Subscriptions")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Albums", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artists", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Songs", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscriptions", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Users", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
