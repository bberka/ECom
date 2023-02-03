using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Products_ProductId",
                table: "BasketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Users_UserId",
                table: "BasketProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketProducts",
                table: "BasketProducts");

            migrationBuilder.RenameTable(
                name: "BasketProducts",
                newName: "Carts");

            migrationBuilder.RenameColumn(
                name: "LastNotFoundate",
                table: "Carts",
                newName: "LastUpdateDate");

            migrationBuilder.RenameIndex(
                name: "IX_BasketProducts_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketProducts_ProductId",
                table: "Carts",
                newName: "IX_Carts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "BasketProducts");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "BasketProducts",
                newName: "LastNotFoundate");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "BasketProducts",
                newName: "IX_BasketProducts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ProductId",
                table: "BasketProducts",
                newName: "IX_BasketProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketProducts",
                table: "BasketProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Products_ProductId",
                table: "BasketProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Users_UserId",
                table: "BasketProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
