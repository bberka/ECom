using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRoles",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                table: "PermissionRoles",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Roles_RoleId",
                table: "PermissionRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Roles_RoleId",
                table: "PermissionRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "PermissionRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "PermissionRoles");
        }
    }
}
