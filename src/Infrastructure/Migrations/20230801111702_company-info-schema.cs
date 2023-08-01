using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class companyinfoschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CompanyInformation",
                schema: "ECOperation",
                newName: "CompanyInformation",
                newSchema: "ECOption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CompanyInformation",
                schema: "ECOption",
                newName: "CompanyInformation",
                newSchema: "ECOperation");
        }
    }
}
