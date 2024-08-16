using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInPlaylistSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlaylistsSongs",
                columns: new[] { "PlaylistSongsID", "PlaylistID", "SongID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 4, 5 },
                    { 6, 5, 1 },
                    { 7, 5, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongsID",
                keyValue: 7);
        }
    }
}
