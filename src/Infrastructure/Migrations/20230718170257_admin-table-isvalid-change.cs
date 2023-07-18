using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class admintableisvalidchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                schema: "ECOperation",
                table: "Admins");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "AdminDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "AdminEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "AdminDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "AdminGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "AdminGetAll");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "AdminCreate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "AnnouncementUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "AnnouncementDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "AnnouncementAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "AnnouncementEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "AnnouncementDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "CategoryAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "CategoryUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "CategoryDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "CategoryEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "CategoryDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "SubCategoryEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "SubCategoryDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "CompanyInfoAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "CompanyInfoUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "ImageUpload");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "OptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "OptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "CargoOptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "CargoOptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "CargoOptionDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "PaymentOptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "PaymentOptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "PaymentOptionDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "SmtpOptionGet");

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Permissions",
                columns: new[] { "Id", "IsValid", "Memo", "Name" },
                values: new object[,]
                {
                    { 32, true, null, "SmtpOptionUpdate" },
                    { 33, true, null, "SmtpOptionDelete" },
                    { 34, true, null, "AdminRecoverAccount" }
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 33, 1 });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "PermissionRoles",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 34, 1 });

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                schema: "ECOperation",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsValid",
                value: true);

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsValid",
                value: true);

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsValid",
                value: true);

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "AdminDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "AdminGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "AdminGetAll");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "AdminCreate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "AnnouncementUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "AnnouncementDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "AnnouncementAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "AnnouncementEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "AnnouncementDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "CategoryAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "CategoryUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "CategoryDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "CategoryEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "CategoryDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "SubCategoryEnable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "SubCategoryDisable");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "CompanyInfoAdd");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "CompanyInfoUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "ImageUpload");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "OptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "OptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "CargoOptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "CargoOptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "CargoOptionDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "PaymentOptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "PaymentOptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "PaymentOptionDelete");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "SmtpOptionGet");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "SmtpOptionUpdate");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "SmtpOptionDelete");
        }
    }
}
