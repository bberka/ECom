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
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles");

            migrationBuilder.DropIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "PermissionRoles");

            migrationBuilder.DropColumn(
                name: "PermissionsId",
                table: "PermissionRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles",
                columns: new[] { "RoleId", "PermissionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PermissionsId",
                table: "PermissionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles",
                columns: new[] { "RolesId", "PermissionsId" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRoles",
                column: "RoleId");
        }
    }
}
