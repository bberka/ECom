using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schemasadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Roles_RoleId",
                table: "PermissionRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRole",
                table: "PermissionRole");

            migrationBuilder.EnsureSchema(
                name: "Log");

            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.EnsureSchema(
                name: "Option");

            migrationBuilder.RenameTable(
                name: "UserLogs",
                newName: "UserLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "SmtpOptions",
                newName: "SmtpOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "SecurityLogs",
                newName: "SecurityLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permissions",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "PaymentOptions",
                newName: "PaymentOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Options",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "CargoOptions",
                newName: "CargoOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admins",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "AdminLogs",
                newName: "AdminLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "PermissionRole",
                newName: "PermissionRoles",
                newSchema: "Operation");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_PermissionId",
                schema: "Operation",
                table: "PermissionRoles",
                newName: "IX_PermissionRoles_PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                schema: "Operation",
                table: "PermissionRoles",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                schema: "Operation",
                table: "PermissionRoles",
                column: "PermissionId",
                principalSchema: "Operation",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Roles_RoleId",
                schema: "Operation",
                table: "PermissionRoles",
                column: "RoleId",
                principalSchema: "Operation",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                schema: "Operation",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Roles_RoleId",
                schema: "Operation",
                table: "PermissionRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                schema: "Operation",
                table: "PermissionRoles");

            migrationBuilder.RenameTable(
                name: "UserLogs",
                schema: "Log",
                newName: "UserLogs");

            migrationBuilder.RenameTable(
                name: "SmtpOptions",
                schema: "Option",
                newName: "SmtpOptions");

            migrationBuilder.RenameTable(
                name: "SecurityLogs",
                schema: "Log",
                newName: "SecurityLogs");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Operation",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "Operation",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "PaymentOptions",
                schema: "Option",
                newName: "PaymentOptions");

            migrationBuilder.RenameTable(
                name: "Options",
                schema: "Option",
                newName: "Options");

            migrationBuilder.RenameTable(
                name: "CargoOptions",
                schema: "Option",
                newName: "CargoOptions");

            migrationBuilder.RenameTable(
                name: "Admins",
                schema: "Operation",
                newName: "Admins");

            migrationBuilder.RenameTable(
                name: "AdminLogs",
                schema: "Log",
                newName: "AdminLogs");

            migrationBuilder.RenameTable(
                name: "PermissionRoles",
                schema: "Operation",
                newName: "PermissionRole");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRole",
                table: "PermissionRole",
                columns: new[] { "RoleId", "PermissionId" });

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
    }
}
