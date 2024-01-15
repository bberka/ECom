using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Database.Migrations
{
    /// <inheritdoc />
    public partial class migtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                schema: "ECPrivate",
                table: "Announcements");

            migrationBuilder.AlterColumn<short>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Sliders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "DefaultCurrencyType",
                schema: "ECOption",
                table: "Options",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Images",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Contents",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                schema: "ECPrivate",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<short>(
                name: "Culture",
                schema: "ECOperation",
                table: "Admins",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
                columns: new[] { "Culture", "RegisterDate" },
                values: new object[] { (short)0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "ECOption",
                table: "Options",
                keyColumn: "Key",
                keyValue: true,
                column: "DefaultCurrencyType",
                value: (short)0);

            migrationBuilder.UpdateData(
                schema: "ECPrivate",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
                columns: new[] { "Culture", "RegisterDate" },
                values: new object[] { (short)0, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentId",
                schema: "ECPrivate",
                table: "Announcements");

            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Sliders",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultCurrencyType",
                schema: "ECOption",
                table: "Options",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                schema: "ECPrivate",
                table: "Contents",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "ECPrivate",
                table: "Announcements",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Culture",
                schema: "ECOperation",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
                columns: new[] { "Culture", "RegisterDate" },
                values: new object[] { 0, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "ECOption",
                table: "Options",
                keyColumn: "Key",
                keyValue: true,
                column: "DefaultCurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "ECPrivate",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
                columns: new[] { "Culture", "RegisterDate" },
                values: new object[] { 0, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
