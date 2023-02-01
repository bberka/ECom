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
                name: "FK_ProductImageBinds_Images_ImageId",
                table: "ProductImageBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageBinds_Products_ProductId",
                table: "ProductImageBinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageBinds",
                table: "ProductImageBinds");

            migrationBuilder.DropIndex(
                name: "IX_ProductImageBinds_ProductId",
                table: "ProductImageBinds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductImageBinds");

            migrationBuilder.DropColumn(
                name: "JwtSecret_Admin",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsEnabledTwoFactor",
                table: "Admins");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "RoleBinds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImageBinds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "ProductImageBinds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProductCommentId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "TwoFactorType",
                table: "Admins",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Addresses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageBinds",
                table: "ProductImageBinds",
                columns: new[] { "ProductId", "ImageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_AdminId",
                table: "Permission",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductCommentId",
                table: "Images",
                column: "ProductCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ProductComments_ProductCommentId",
                table: "Images",
                column: "ProductCommentId",
                principalTable: "ProductComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Admins_AdminId",
                table: "Permission",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageBinds_Images_ImageId",
                table: "ProductImageBinds",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageBinds_Products_ProductId",
                table: "ProductImageBinds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ProductComments_ProductCommentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Admins_AdminId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageBinds_Images_ImageId",
                table: "ProductImageBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageBinds_Products_ProductId",
                table: "ProductImageBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageBinds",
                table: "ProductImageBinds");

            migrationBuilder.DropIndex(
                name: "IX_Permission_AdminId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductCommentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "RoleBinds");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "ProductCommentId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "ProductImageBinds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductImageBinds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductImageBinds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "JwtSecret_Admin",
                table: "Options",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte>(
                name: "TwoFactorType",
                table: "Admins",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabledTwoFactor",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageBinds",
                table: "ProductImageBinds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImageBinds_ProductId",
                table: "ProductImageBinds",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageBinds_Images_ImageId",
                table: "ProductImageBinds",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageBinds_Products_ProductId",
                table: "ProductImageBinds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
