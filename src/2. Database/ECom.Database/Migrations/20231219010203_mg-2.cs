using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Database.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescriptionLanguageKey",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "ShortDescriptionContentId");

            migrationBuilder.RenameColumn(
                name: "NameLanguageKey",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "NameContentId");

            migrationBuilder.RenameColumn(
                name: "DescriptionMarkdownLanguageKey",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "DescriptionMarkdownContentId");

            migrationBuilder.RenameColumn(
                name: "Key",
                schema: "ECPrivate",
                table: "Contents",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortDescriptionContentId",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "ShortDescriptionLanguageKey");

            migrationBuilder.RenameColumn(
                name: "NameContentId",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "NameLanguageKey");

            migrationBuilder.RenameColumn(
                name: "DescriptionMarkdownContentId",
                schema: "ECPrivate",
                table: "ProductDetails",
                newName: "DescriptionMarkdownLanguageKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "ECPrivate",
                table: "Contents",
                newName: "Key");
        }
    }
}
