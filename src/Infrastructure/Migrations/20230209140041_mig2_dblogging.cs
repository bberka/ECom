using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig2dblogging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestLogs");

            migrationBuilder.AlterColumn<string>(
                name: "OperationName",
                table: "UserLogs",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ErrorCode",
                table: "UserLogs",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResultErrors",
                table: "UserLogs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rv",
                table: "UserLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OperationName",
                table: "AdminLogs",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ErrorCode",
                table: "AdminLogs",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResultErrors",
                table: "AdminLogs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rv",
                table: "AdminLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "ResultErrors",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "Rv",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "AdminLogs");

            migrationBuilder.DropColumn(
                name: "ResultErrors",
                table: "AdminLogs");

            migrationBuilder.DropColumn(
                name: "Rv",
                table: "AdminLogs");

            migrationBuilder.AlterColumn<string>(
                name: "OperationName",
                table: "UserLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "OperationName",
                table: "AdminLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.CreateTable(
                name: "TestLogs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLogs", x => x.Guid);
                });
        }
    }
}
