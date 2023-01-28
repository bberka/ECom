using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class optiontable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Options",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Options",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavIcoImageId",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoImageId",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowStock",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Options",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "WhatsApp",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "FavIcoImageId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "LogoImageId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ShowStock",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Options");
        }
    }
}
