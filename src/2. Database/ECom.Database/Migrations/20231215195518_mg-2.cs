using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ECEnum");

            migrationBuilder.RenameTable(
                name: "ProductAttributeTypes",
                schema: "ECPrivate",
                newName: "ProductAttributeTypes",
                newSchema: "ECEnum");

            migrationBuilder.CreateTable(
                name: "EmailQueue",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    NextRetryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastRetryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailQueue_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueue_UserId",
                schema: "ECPrivate",
                table: "EmailQueue",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailQueue",
                schema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ProductAttributeTypes",
                schema: "ECEnum",
                newName: "ProductAttributeTypes",
                newSchema: "ECPrivate");
        }
    }
}
