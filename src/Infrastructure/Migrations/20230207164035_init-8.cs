using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOptions_Languages_LanguageCulture",
                table: "CargoOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Languages_Culture",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptions_Languages_LanguageCulture",
                table: "PaymentOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Languages_LanguageCulture",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_Languages_LanguageCulture",
                table: "Sliders");

            migrationBuilder.DropTable(
                name: "ImageLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_LanguageCulture",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_LanguageCulture",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_AdminId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentOptions_LanguageCulture",
                table: "PaymentOptions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Culture",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CargoOptions_LanguageCulture",
                table: "CargoOptions");

            migrationBuilder.DropColumn(
                name: "LanguageCulture",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "LanguageCulture",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LanguageCulture",
                table: "PaymentOptions");

            migrationBuilder.DropColumn(
                name: "LanguageCulture",
                table: "CargoOptions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CargoOptions");

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Users",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Sliders",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "ProductDetails",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "PaymentOptions",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Images",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Categories",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)");

            migrationBuilder.CreateTable(
                name: "ProductCommentStars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCommentStars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCommentStars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentStars_UserId",
                table: "ProductCommentStars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCommentStars");

            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Users",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCulture",
                table: "Sliders",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCulture",
                table: "ProductDetails",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "PaymentOptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCulture",
                table: "PaymentOptions",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "Categories",
                type: "nvarchar(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCulture",
                table: "CargoOptions",
                type: "nvarchar(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CargoOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Culture = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Culture);
                });

            migrationBuilder.CreateTable(
                name: "ImageLanguages",
                columns: table => new
                {
                    Culture = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    LanguageCulture = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLanguages", x => new { x.Culture, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ImageLanguages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageLanguages_Languages_LanguageCulture",
                        column: x => x.LanguageCulture,
                        principalTable: "Languages",
                        principalColumn: "Culture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_LanguageCulture",
                table: "Sliders",
                column: "LanguageCulture");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_LanguageCulture",
                table: "ProductDetails",
                column: "LanguageCulture");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AdminId",
                table: "Permissions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_LanguageCulture",
                table: "PaymentOptions",
                column: "LanguageCulture");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Culture",
                table: "Categories",
                column: "Culture");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOptions_LanguageCulture",
                table: "CargoOptions",
                column: "LanguageCulture");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLanguages_ImageId",
                table: "ImageLanguages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLanguages_LanguageCulture",
                table: "ImageLanguages",
                column: "LanguageCulture");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOptions_Languages_LanguageCulture",
                table: "CargoOptions",
                column: "LanguageCulture",
                principalTable: "Languages",
                principalColumn: "Culture",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Languages_Culture",
                table: "Categories",
                column: "Culture",
                principalTable: "Languages",
                principalColumn: "Culture",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptions_Languages_LanguageCulture",
                table: "PaymentOptions",
                column: "LanguageCulture",
                principalTable: "Languages",
                principalColumn: "Culture");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Languages_LanguageCulture",
                table: "ProductDetails",
                column: "LanguageCulture",
                principalTable: "Languages",
                principalColumn: "Culture");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_Languages_LanguageCulture",
                table: "Sliders",
                column: "LanguageCulture",
                principalTable: "Languages",
                principalColumn: "Culture");
        }
    }
}
