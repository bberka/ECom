using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class announcementtableroletypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageCurrencies", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageLanguages", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManagePlugins", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManagePluginsAndThemes", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageRolesAndPermissions", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageThemes", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Moderator");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "Support");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageCurrencies");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageLanguages");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManagePlugins");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManagePluginsAndThemes");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageRolesAndPermissions");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageThemes");

            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "ECPrivate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                schema: "ECPrivate",
                table: "Announcements");

            migrationBuilder.InsertData(
                schema: "ECEnum",
                table: "Permissions",
                column: "Id",
                values: new object[]
                {
                    "ManageLoginSessions",
                    "ManageQuestions",
                    "ManageRoles"
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "ManageLoginSessions", "Owner" },
                    { "ManageQuestions", "Owner" },
                    { "ManageRoles", "Owner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageLoginSessions", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageQuestions", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { "ManageRoles", "Owner" });

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageLoginSessions");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageQuestions");

            migrationBuilder.DeleteData(
                schema: "ECEnum",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "ManageRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "ECPrivate",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                schema: "ECPrivate",
                table: "Announcements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "ECEnum",
                table: "Permissions",
                column: "Id",
                values: new object[]
                {
                    "ManageCurrencies",
                    "ManageLanguages",
                    "ManagePlugins",
                    "ManagePluginsAndThemes",
                    "ManageRolesAndPermissions",
                    "ManageThemes"
                });

            migrationBuilder.InsertData(
                schema: "ECEnum",
                table: "Roles",
                column: "Id",
                values: new object[]
                {
                    "Admin",
                    "Moderator",
                    "Support"
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "ManageCurrencies", "Owner" },
                    { "ManageLanguages", "Owner" },
                    { "ManagePlugins", "Owner" },
                    { "ManagePluginsAndThemes", "Owner" },
                    { "ManageRolesAndPermissions", "Owner" },
                    { "ManageThemes", "Owner" }
                });
        }
    }
}
