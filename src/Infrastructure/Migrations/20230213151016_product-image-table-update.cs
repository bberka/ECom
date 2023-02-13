using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productimagetableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_Suppliers_SupplierId",
                table: "StockChanges");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "StockChanges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "StockChanges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "StockChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "CompanyInfo_AddOrUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_UserId",
                table: "StockChanges",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_Suppliers_SupplierId",
                table: "StockChanges",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_Users_UserId",
                table: "StockChanges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_Suppliers_SupplierId",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_Users_UserId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_UserId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StockChanges");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "CompanyInfo_UpdateOrAdd");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_Suppliers_SupplierId",
                table: "StockChanges",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
