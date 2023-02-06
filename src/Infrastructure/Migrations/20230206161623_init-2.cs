using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogType",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "LogType",
                table: "AdminLogs");

            migrationBuilder.RenameColumn(
                name: "OperationType",
                table: "UserLogs",
                newName: "Severity");

            migrationBuilder.RenameColumn(
                name: "OperationType",
                table: "AdminLogs",
                newName: "Severity");

            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "UserLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "AdminLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "AdminLogs");

            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "UserLogs",
                newName: "OperationType");

            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "AdminLogs",
                newName: "OperationType");

            migrationBuilder.AddColumn<int>(
                name: "LogType",
                table: "UserLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LogType",
                table: "AdminLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
