using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionProducts_Users_UserId",
                table: "CollectionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_AdminId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_CollectionProducts_UserId",
                table: "CollectionProducts");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "RoleBinds");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CollectionProducts");

            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "RoleBinds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CollectionProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Admins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AdminId",
                table: "Permissions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionProducts_UserId",
                table: "CollectionProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionProducts_Users_UserId",
                table: "CollectionProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
