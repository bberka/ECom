using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Images_FavIcoImageId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Images_LogoImageId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Languages_DefaultLanguageId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_DefaultLanguageId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_FavIcoImageId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_LogoImageId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

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
                name: "DefaultLanguageId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "DomainUrl",
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
                name: "IsDebug",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsMaintenance",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsUseRefreshToken",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "JwtAudience",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "JwtExpireMinutesDefault",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "JwtIssuer",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "JwtSecret",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "LogoImageId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "WebApiUrl",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "JwtValidateIssuer",
                table: "Options",
                newName: "IsAdminOpen");

            migrationBuilder.RenameColumn(
                name: "JwtValidateAudience",
                table: "Options",
                newName: "IsRelease");

            migrationBuilder.RenameColumn(
                name: "JwtExpireMinutesLong",
                table: "Options",
                newName: "PasswordResetTimeoutMinutes");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Options",
                newName: "SelectedCurrency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "IsRelease");

            migrationBuilder.CreateTable(
                name: "CompanyInformations",
                columns: table => new
                {
                    IsRelease = table.Column<bool>(type: "bit", nullable: false),
                    DomainUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    WebApiUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WhatsApp = table.Column<int>(type: "int", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DefaultLanguageId = table.Column<int>(type: "int", nullable: true),
                    LogoImageId = table.Column<int>(type: "int", nullable: true),
                    FavIcoImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformations", x => x.IsRelease);
                });

            migrationBuilder.CreateTable(
                name: "JwtOptions",
                columns: table => new
                {
                    IsRelease = table.Column<bool>(type: "bit", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Audience = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ExpireMinutesDefault = table.Column<int>(type: "int", nullable: false),
                    ExpireMinutesLong = table.Column<int>(type: "int", nullable: false),
                    IsUseRefreshToken = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtOptions", x => x.IsRelease);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInformations");

            migrationBuilder.DropTable(
                name: "JwtOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "SelectedCurrency",
                table: "Options",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "PasswordResetTimeoutMinutes",
                table: "Options",
                newName: "JwtExpireMinutesLong");

            migrationBuilder.RenameColumn(
                name: "IsAdminOpen",
                table: "Options",
                newName: "JwtValidateIssuer");

            migrationBuilder.RenameColumn(
                name: "IsRelease",
                table: "Options",
                newName: "JwtValidateAudience");

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

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Options",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DomainUrl",
                table: "Options",
                type: "nvarchar(128)",
                maxLength: 128,
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
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Options",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDebug",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaintenance",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUseRefreshToken",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JwtAudience",
                table: "Options",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JwtExpireMinutesDefault",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JwtIssuer",
                table: "Options",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JwtSecret",
                table: "Options",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LogoImageId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebApiUrl",
                table: "Options",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "IsOpen");

            migrationBuilder.CreateIndex(
                name: "IX_Options_DefaultLanguageId",
                table: "Options",
                column: "DefaultLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_FavIcoImageId",
                table: "Options",
                column: "FavIcoImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_LogoImageId",
                table: "Options",
                column: "LogoImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Images_FavIcoImageId",
                table: "Options",
                column: "FavIcoImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Images_LogoImageId",
                table: "Options",
                column: "LogoImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Languages_DefaultLanguageId",
                table: "Options",
                column: "DefaultLanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }
    }
}
