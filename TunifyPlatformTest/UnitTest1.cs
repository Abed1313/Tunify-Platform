using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Packaging;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Servises;

namespace TunifyPlatformTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TunifyDbContext>()
                .UseInMemoryDatabase(databaseName: "TunifyTestDb")
                .Options;

            using (var context = new TunifyDbContext(options))
            {
                var playlist = new Playlist { PlaylistID = 1, PlaylistName = "My Playlist", PlaylistSongs = new List<PlaylistSongs>() };
                var songs = new List<Songs>
                {
                    new Songs { SongsID = 3, Title = "Song 1", ArtistID = 1, AlbumID = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
                    new Songs { SongsID = 4, Title = "Song 2", ArtistID = 2, AlbumID = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Rock" }
                };

                // Create PlaylistSongs instances to establish the many-to-many relationship
                var playlistSongs = new List<PlaylistSongs>
                {
                    new PlaylistSongs { PlaylistID = playlist.PlaylistID, SongID = songs[0].SongsID, Playlist = playlist, Songs = songs[0] },
                    new PlaylistSongs { PlaylistID = playlist.PlaylistID, SongID = songs[1].SongsID, Playlist = playlist, Songs = songs[1] }
                };

                playlist.PlaylistSongs.AddRange(playlistSongs);

                context.Playlists.Add(playlist);
                context.Songs.AddRange(songs);
                context.PlaylistsSongs.AddRange(playlistSongs);
                await context.SaveChangesAsync();

                var service = new PlaylistServises(context);

                // Act
                var result = await service.GetSongsForPlaylist(playlist.PlaylistID);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, s => s.Title == "Song 1");
                Assert.Contains(result, s => s.Title == "Song 2");
            }
        }
    }
}