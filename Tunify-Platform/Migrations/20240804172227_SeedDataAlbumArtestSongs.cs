using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAlbumArtestSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistsID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Bio of Artist One", "Artist One" },
                    { 2, "Bio of Artist Two", "Artist Two" },
                    { 3, "Bio of Artist Three", "Artist Three" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumsID", "AlbumName", "ArtistID", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Album One", 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Album Two", 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Album Three", 3, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongsID", "AlbumID", "ArtistID", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 45, 0), "Pop", "Song One" },
                    { 2, 2, 2, new TimeSpan(0, 0, 4, 12, 0), "Rock", "Song Two" },
                    { 3, 3, 3, new TimeSpan(0, 0, 2, 58, 0), "Jazz", "Song Three" },
                    { 4, 1, 1, new TimeSpan(0, 0, 3, 22, 0), "Pop", "Song Four" },
                    { 5, 2, 2, new TimeSpan(0, 0, 5, 30, 0), "Rock", "Song Five" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongsID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumsID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsID",
                keyValue: 3);
        }
    }
}
