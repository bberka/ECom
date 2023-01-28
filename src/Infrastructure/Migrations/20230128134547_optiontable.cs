using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class optiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Key = table.Column<byte>(type: "tinyint", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsMaintenance = table.Column<bool>(type: "bit", nullable: false),
                    IsDebug = table.Column<bool>(type: "bit", nullable: false),
                    JwtSecret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtAudience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtExpireMinutesDefault = table.Column<int>(type: "int", nullable: false),
                    JwtExpireMinutesLong = table.Column<int>(type: "int", nullable: false),
                    IsUseRefreshToken = table.Column<bool>(type: "bit", nullable: false),
                    PagingProductCount = table.Column<byte>(type: "tinyint", nullable: false),
                    UsernameMinLength = table.Column<byte>(type: "tinyint", nullable: false),
                    UsernameMaxLength = table.Column<byte>(type: "tinyint", nullable: false),
                    PasswordMinLength = table.Column<byte>(type: "tinyint", nullable: false),
                    PasswordMaxLength = table.Column<byte>(type: "tinyint", nullable: false),
                    RequireStrongPassword = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");
        }
    }
}
