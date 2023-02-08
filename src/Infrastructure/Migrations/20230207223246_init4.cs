using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductComments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsApp",
                table: "CompanyInformations",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId1",
                table: "ProductComments",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Products_ProductId1",
                table: "ProductComments",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Products_ProductId1",
                table: "ProductComments");

            migrationBuilder.DropIndex(
                name: "IX_ProductComments_ProductId1",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductComments");

            migrationBuilder.AlterColumn<int>(
                name: "WhatsApp",
                table: "CompanyInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
