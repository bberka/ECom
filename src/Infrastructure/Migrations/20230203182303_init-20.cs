using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastPasswordUpdateDate",
                table: "Users",
                newName: "PasswordLastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "LastPasswordNotFoundate",
                table: "Admins",
                newName: "PasswordLastUpdateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordLastUpdateDate",
                table: "Users",
                newName: "LastPasswordUpdateDate");

            migrationBuilder.RenameColumn(
                name: "PasswordLastUpdateDate",
                table: "Admins",
                newName: "LastPasswordNotFoundate");
        }
    }
}
