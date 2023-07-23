using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedrefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshJwtToken",
                schema: "ECPrivate",
                table: "Users",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshJwtToken",
                schema: "ECOperation",
                table: "Admins",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "ECOperation",
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
                column: "RefreshJwtToken",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshJwtToken",
                schema: "ECPrivate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshJwtToken",
                schema: "ECOperation",
                table: "Admins");
        }
    }
}
