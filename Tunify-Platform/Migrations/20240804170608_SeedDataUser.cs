using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersID", "Email", "JoinDate", "SubscriptionID", "Username" },
                values: new object[,]
                {
                    { 1, "Abed@gmail.com", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Abed" },
                    { 2, "Britta@gmail.com", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Britta" },
                    { 3, "Shirley@gmail.com", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Shirley" },
                    { 4, "Annie@gmail.com", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Annie" },
                    { 5, "Troy@gmail.com", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Troy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersID",
                keyValue: 5);
        }
    }
}
