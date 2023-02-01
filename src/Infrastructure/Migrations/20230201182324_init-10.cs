using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Admins_AdminId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleBinds_Permission_PermissionId",
                table: "RoleBinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_AdminId",
                table: "Permissions",
                newName: "IX_Permissions_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleBinds_Permissions_PermissionId",
                table: "RoleBinds",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Admins_AdminId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleBinds_Permissions_PermissionId",
                table: "RoleBinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_AdminId",
                table: "Permission",
                newName: "IX_Permission_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Admins_AdminId",
                table: "Permission",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleBinds_Permission_PermissionId",
                table: "RoleBinds",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id");
        }
    }
}
