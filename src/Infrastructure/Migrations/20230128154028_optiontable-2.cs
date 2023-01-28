using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class optiontable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PasswordMaxLength",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UsernameMaxLength",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "RequireStrongPassword",
                table: "Options",
                newName: "RequireUpperCaseInPassword");

            migrationBuilder.AddColumn<string>(
                name: "ApiUrl",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DomainUrl",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordAllowedSpecialCharacters",
                table: "Options",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireLowerCaseInPassword",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequireNumberInPassword",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequireSpecialCharacterInPassword",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsernameAllowedSpecialCharacters",
                table: "Options",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "IsOpen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ApiUrl",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "DomainUrl",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PasswordAllowedSpecialCharacters",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "RequireLowerCaseInPassword",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "RequireNumberInPassword",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "RequireSpecialCharacterInPassword",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UsernameAllowedSpecialCharacters",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "RequireUpperCaseInPassword",
                table: "Options",
                newName: "RequireStrongPassword");

            migrationBuilder.AddColumn<byte>(
                name: "Key",
                table: "Options",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PasswordMaxLength",
                table: "Options",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "UsernameMaxLength",
                table: "Options",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Key");
        }
    }
}
