using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddRelastionShip2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionID",
                table: "Users",
                column: "SubscriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSongs_PlaylistID",
                table: "PlaylistsSongs",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSongs_SongID",
                table: "PlaylistsSongs",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserID",
                table: "Playlists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistID",
                table: "Albums",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistID",
                table: "Albums",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserID",
                table: "Playlists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsSongs_Playlists_PlaylistID",
                table: "PlaylistsSongs",
                column: "PlaylistID",
                principalTable: "Playlists",
                principalColumn: "PlaylistID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsSongs_Songs_SongID",
                table: "PlaylistsSongs",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "SongsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "AlbumsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionID",
                table: "Users",
                column: "SubscriptionID",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistID",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserID",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsSongs_Playlists_PlaylistID",
                table: "PlaylistsSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsSongs_Songs_SongID",
                table: "PlaylistsSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumID",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscriptions_SubscriptionID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistsSongs_PlaylistID",
                table: "PlaylistsSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistsSongs_SongID",
                table: "PlaylistsSongs");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserID",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistID",
                table: "Albums");
        }
    }
}
