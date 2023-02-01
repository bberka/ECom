using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Categories_PreferredLanguageId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Languages_PreferredLanguageId",
                table: "Users",
                column: "PreferredLanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Languages_PreferredLanguageId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Categories_PreferredLanguageId",
                table: "Users",
                column: "PreferredLanguageId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
