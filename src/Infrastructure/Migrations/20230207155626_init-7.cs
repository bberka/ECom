using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductComments_ProductCommentId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductCommentId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductCommentId",
                table: "ProductImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCommentId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductCommentId",
                table: "ProductImages",
                column: "ProductCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductComments_ProductCommentId",
                table: "ProductImages",
                column: "ProductCommentId",
                principalTable: "ProductComments",
                principalColumn: "Id");
        }
    }
}
