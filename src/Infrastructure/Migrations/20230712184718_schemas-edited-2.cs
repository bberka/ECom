using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schemasedited2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerifyToken_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerifyToken",
                schema: "ECPrivate",
                table: "EmailVerifyToken");

            migrationBuilder.RenameTable(
                name: "Options",
                schema: "Option",
                newName: "Options",
                newSchema: "ECOption");

            migrationBuilder.RenameTable(
                name: "EmailVerifyToken",
                schema: "ECPrivate",
                newName: "EmailVerifyTokens",
                newSchema: "ECPrivate");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerifyToken_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyTokens",
                newName: "IX_EmailVerifyTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerifyTokens",
                schema: "ECPrivate",
                table: "EmailVerifyTokens",
                column: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerifyTokens_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyTokens",
                column: "UserId",
                principalSchema: "ECPrivate",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerifyTokens_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerifyTokens",
                schema: "ECPrivate",
                table: "EmailVerifyTokens");

            migrationBuilder.EnsureSchema(
                name: "Option");

            migrationBuilder.RenameTable(
                name: "Options",
                schema: "ECOption",
                newName: "Options",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "EmailVerifyTokens",
                schema: "ECPrivate",
                newName: "EmailVerifyToken",
                newSchema: "ECPrivate");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerifyTokens_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                newName: "IX_EmailVerifyToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerifyToken",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                column: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerifyToken_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                column: "UserId",
                principalSchema: "ECPrivate",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
