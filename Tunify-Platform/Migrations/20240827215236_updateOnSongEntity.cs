using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class updateOnSongEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "AlbumsID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "AlbumsID");
        }
    }
}
