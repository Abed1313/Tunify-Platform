using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataPlayList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistID", "CreatedDate", "PlaylistName", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chill Vibes", 1 },
                    { 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workout Hits", 2 },
                    { 3, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road Trip", 3 },
                    { 4, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Study Session", 4 },
                    { 5, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Party Time", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistID",
                keyValue: 5);
        }
    }
}
