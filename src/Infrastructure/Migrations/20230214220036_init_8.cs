using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionsId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Roles_RolesId",
                table: "PermissionRole");

            migrationBuilder.DropTable(
                name: "PermissionRoles");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "PermissionRole",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "PermissionsId",
                table: "PermissionRole",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_RolesId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionId",
                table: "PermissionRole",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Roles_RoleId",
                table: "PermissionRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Roles_RoleId",
                table: "PermissionRole");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "PermissionRole",
                newName: "RolesId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "PermissionRole",
                newName: "PermissionsId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_PermissionId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_RolesId");

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRoles",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionsId",
                table: "PermissionRole",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Roles_RolesId",
                table: "PermissionRole",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
