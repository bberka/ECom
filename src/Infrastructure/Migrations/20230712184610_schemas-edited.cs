using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schemasedited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerifyTokens_Users_UserId",
                table: "EmailVerifyTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerifyTokens",
                table: "EmailVerifyTokens");

            migrationBuilder.EnsureSchema(
                name: "ECPrivate");

            migrationBuilder.EnsureSchema(
                name: "ECLog");

            migrationBuilder.EnsureSchema(
                name: "ECOperation");

            migrationBuilder.EnsureSchema(
                name: "ECOption");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "UserLogs",
                schema: "Log",
                newName: "UserLogs",
                newSchema: "ECLog");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Suppliers",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategories",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "StockChanges",
                newName: "StockChanges",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "SmtpOptions",
                schema: "Option",
                newName: "SmtpOptions",
                newSchema: "ECOption");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "Sliders",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ShowCaseImages",
                newName: "ShowCaseImages",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "SecurityLogs",
                schema: "Log",
                newName: "SecurityLogs",
                newSchema: "ECLog");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Operation",
                newName: "Roles",
                newSchema: "ECOperation");

            migrationBuilder.RenameTable(
                name: "ProductVariants",
                newName: "ProductVariants",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ProductSubCategories",
                newName: "ProductSubCategories",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ProductShowCases",
                newName: "ProductShowCases",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetails",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "ProductComments",
                newName: "ProductComments",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "Operation",
                newName: "Permissions",
                newSchema: "ECOperation");

            migrationBuilder.RenameTable(
                name: "PermissionRoles",
                schema: "Operation",
                newName: "PermissionRoles",
                newSchema: "ECOperation");

            migrationBuilder.RenameTable(
                name: "PaymentOptions",
                schema: "Option",
                newName: "PaymentOptions",
                newSchema: "ECOption");

            migrationBuilder.RenameTable(
                name: "PasswordResetTokens",
                newName: "PasswordResetTokens",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Images",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "FavoriteProducts",
                newName: "FavoriteProducts",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "DiscountNotifies",
                newName: "DiscountNotifies",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "DiscountCoupons",
                newName: "DiscountCoupons",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "CompanyInformations",
                newName: "CompanyInformations",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Collections",
                newName: "Collections",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "CollectionProducts",
                newName: "CollectionProducts",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "CategoryDiscounts",
                newName: "CategoryDiscounts",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Carts",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "CargoOptions",
                schema: "Option",
                newName: "CargoOptions",
                newSchema: "ECOption");

            migrationBuilder.RenameTable(
                name: "Announcements",
                newName: "Announcements",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "Admins",
                schema: "Operation",
                newName: "Admins",
                newSchema: "ECOperation");

            migrationBuilder.RenameTable(
                name: "AdminLogs",
                schema: "Log",
                newName: "AdminLogs",
                newSchema: "ECLog");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresses",
                newSchema: "ECPrivate");

            migrationBuilder.RenameTable(
                name: "EmailVerifyTokens",
                newName: "EmailVerifyToken",
                newSchema: "ECPrivate");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerifyTokens_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                newName: "IX_EmailVerifyToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerifyToken",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                column: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerifyToken_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken",
                column: "UserId",
                principalSchema: "ECPrivate",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailVerifyToken_Users_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailVerifyToken",
                schema: "ECPrivate",
                table: "EmailVerifyToken");

            migrationBuilder.EnsureSchema(
                name: "Log");

            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "ECPrivate",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserLogs",
                schema: "ECLog",
                newName: "UserLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "ECPrivate",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                schema: "ECPrivate",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "StockChanges",
                schema: "ECPrivate",
                newName: "StockChanges");

            migrationBuilder.RenameTable(
                name: "SmtpOptions",
                schema: "ECOption",
                newName: "SmtpOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "Sliders",
                schema: "ECPrivate",
                newName: "Sliders");

            migrationBuilder.RenameTable(
                name: "ShowCaseImages",
                schema: "ECPrivate",
                newName: "ShowCaseImages");

            migrationBuilder.RenameTable(
                name: "SecurityLogs",
                schema: "ECLog",
                newName: "SecurityLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "ECOperation",
                newName: "Roles",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "ProductVariants",
                schema: "ECPrivate",
                newName: "ProductVariants");

            migrationBuilder.RenameTable(
                name: "ProductSubCategories",
                schema: "ECPrivate",
                newName: "ProductSubCategories");

            migrationBuilder.RenameTable(
                name: "ProductShowCases",
                schema: "ECPrivate",
                newName: "ProductShowCases");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "ECPrivate",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                schema: "ECPrivate",
                newName: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ProductComments",
                schema: "ECPrivate",
                newName: "ProductComments");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "ECOperation",
                newName: "Permissions",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "PermissionRoles",
                schema: "ECOperation",
                newName: "PermissionRoles",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "PaymentOptions",
                schema: "ECOption",
                newName: "PaymentOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "PasswordResetTokens",
                schema: "ECPrivate",
                newName: "PasswordResetTokens");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "ECPrivate",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Images",
                schema: "ECPrivate",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "FavoriteProducts",
                schema: "ECPrivate",
                newName: "FavoriteProducts");

            migrationBuilder.RenameTable(
                name: "DiscountNotifies",
                schema: "ECPrivate",
                newName: "DiscountNotifies");

            migrationBuilder.RenameTable(
                name: "DiscountCoupons",
                schema: "ECPrivate",
                newName: "DiscountCoupons");

            migrationBuilder.RenameTable(
                name: "CompanyInformations",
                schema: "ECPrivate",
                newName: "CompanyInformations");

            migrationBuilder.RenameTable(
                name: "Collections",
                schema: "ECPrivate",
                newName: "Collections");

            migrationBuilder.RenameTable(
                name: "CollectionProducts",
                schema: "ECPrivate",
                newName: "CollectionProducts");

            migrationBuilder.RenameTable(
                name: "CategoryDiscounts",
                schema: "ECPrivate",
                newName: "CategoryDiscounts");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "ECPrivate",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "ECPrivate",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "CargoOptions",
                schema: "ECOption",
                newName: "CargoOptions",
                newSchema: "Option");

            migrationBuilder.RenameTable(
                name: "Announcements",
                schema: "ECPrivate",
                newName: "Announcements");

            migrationBuilder.RenameTable(
                name: "Admins",
                schema: "ECOperation",
                newName: "Admins",
                newSchema: "Operation");

            migrationBuilder.RenameTable(
                name: "AdminLogs",
                schema: "ECLog",
                newName: "AdminLogs",
                newSchema: "Log");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "ECPrivate",
                newName: "Addresses");

            migrationBuilder.RenameTable(
                name: "EmailVerifyToken",
                schema: "ECPrivate",
                newName: "EmailVerifyTokens");

            migrationBuilder.RenameIndex(
                name: "IX_EmailVerifyToken_UserId",
                table: "EmailVerifyTokens",
                newName: "IX_EmailVerifyTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailVerifyTokens",
                table: "EmailVerifyTokens",
                column: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailVerifyTokens_Users_UserId",
                table: "EmailVerifyTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
