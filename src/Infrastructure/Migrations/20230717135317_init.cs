using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ECPrivate");

            migrationBuilder.EnsureSchema(
                name: "ECLog");

            migrationBuilder.EnsureSchema(
                name: "ECOperation");

            migrationBuilder.EnsureSchema(
                name: "ECOption");

            migrationBuilder.CreateTable(
                name: "Announcements",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "ECPrivate",
                columns: table => new
                {
                    NameKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ParentNameKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.NameKey);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInformations",
                schema: "ECPrivate",
                columns: table => new
                {
                    IsRelease = table.Column<bool>(type: "bit", nullable: false),
                    DomainUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    WebApiUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LogoImageId = table.Column<int>(type: "int", nullable: true),
                    FavIcoImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformations", x => x.IsRelease);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationStrings",
                schema: "ECPrivate",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Language = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationStrings", x => new { x.Key, x.Language });
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "ECOption",
                columns: table => new
                {
                    IsRelease = table.Column<bool>(type: "bit", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminOpen = table.Column<bool>(type: "bit", nullable: false),
                    PagingProductCount = table.Column<byte>(type: "tinyint", nullable: false),
                    RequireUpperCaseInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireLowerCaseInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireSpecialCharacterInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireNumberInPassword = table.Column<bool>(type: "bit", nullable: false),
                    EmailVerificationTimeoutMinutes = table.Column<int>(type: "int", nullable: false),
                    PasswordResetTimeoutMinutes = table.Column<int>(type: "int", nullable: false),
                    SelectedCurrency = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ShowStock = table.Column<bool>(type: "bit", nullable: false),
                    ProductImageLimit = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductCommentImageLimit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.IsRelease);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                schema: "ECOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "ECOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "ECPrivate",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.SubCategoryId });
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "ECOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityLogs",
                schema: "ECLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HttpStatusCodeResponse = table.Column<int>(type: "int", nullable: false),
                    RequestUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    QueryString = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    XReal_IpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CFConnecting_IpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Params = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpOptions",
                schema: "ECOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ssl = table.Column<bool>(type: "bit", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CitizenShipNumber = table.Column<int>(type: "int", nullable: true),
                    TaxNumber = table.Column<int>(type: "int", nullable: true),
                    OAuthKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OAuthType = table.Column<byte>(type: "tinyint", nullable: true),
                    TwoFactorKey = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TwoFactorType = table.Column<byte>(type: "tinyint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDiscounts",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryNameKey = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDiscounts_Categories_CategoryNameKey",
                        column: x => x.CategoryNameKey,
                        principalSchema: "ECPrivate",
                        principalTable: "Categories",
                        principalColumn: "NameKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCoupons",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountCategoryId = table.Column<int>(type: "int", nullable: false),
                    DiscountCategoryNameKey = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCoupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCoupons_Categories_DiscountCategoryNameKey",
                        column: x => x.DiscountCategoryNameKey,
                        principalSchema: "ECPrivate",
                        principalTable: "Categories",
                        principalColumn: "NameKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoOptions",
                schema: "ECOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreeShippingMinCost = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoOptions_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "ECPrivate",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowCaseImages",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    ShowCaseType = table.Column<byte>(type: "tinyint", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCaseImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowCaseImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "ECPrivate",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "ECPrivate",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountedPriceIncludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPriceIncludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalSchema: "ECPrivate",
                        principalTable: "ProductVariants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                schema: "ECOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TwoFactorKey = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TwoFactorType = table.Column<byte>(type: "tinyint", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ECOperation",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                schema: "ECOperation",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "ECOperation",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ECOperation",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Provience = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerifyTokens",
                schema: "ECPrivate",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifyTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_EmailVerifyTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                schema: "ECPrivate",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                schema: "ECLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    OperationName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Rv = table.Column<int>(type: "int", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    XReal_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CFConnecting_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ResultErrors = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Params = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "ECPrivate",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountNotifies",
                schema: "ECPrivate",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountNotifies", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DiscountNotifies_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountNotifies_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                schema: "ECPrivate",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountedPrice = table.Column<double>(type: "float", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscountCouponId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DiscountCoupons_DiscountCouponId",
                        column: x => x.DiscountCouponId,
                        principalSchema: "ECPrivate",
                        principalTable: "DiscountCoupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComments",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Star = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DescriptionMarkdown = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    TechnicalInformationMarkdown = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                schema: "ECPrivate",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "ECPrivate",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShowCases",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    ShowCaseType = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShowCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShowCases_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockChanges",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockChanges_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockChanges_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "ECPrivate",
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockChanges_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminLogs",
                schema: "ECLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    OperationName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Rv = table.Column<int>(type: "int", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    XReal_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CFConnecting_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Params = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ResultErrors = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminLogs_Admins_AdminId",
                        column: x => x.AdminId,
                        principalSchema: "ECOperation",
                        principalTable: "Admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollectionProducts",
                schema: "ECPrivate",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionProducts", x => new { x.ProductId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_CollectionProducts_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "ECPrivate",
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "ECPrivate",
                table: "CompanyInformations",
                columns: new[] { "IsRelease", "CompanyAddress", "CompanyName", "ContactEmail", "Description", "DomainUrl", "FacebookLink", "FavIcoImageId", "InstagramLink", "LogoImageId", "PhoneNumber", "WebApiUrl", "WhatsApp", "YoutubeLink" },
                values: new object[,]
                {
                    { false, "Address", "ECom.Company", "contact@support.com", "Company Description", "www.company.com", "facebook.com/company", null, "instagram.com/company", null, "5526667788", "api.company.com", "5526667788", "yt.com/company" },
                    { true, "Address", "ECom.Company", "contact@support.com", "Company Description", "www.company.com", "facebook.com/company", null, "instagram.com/company", null, "5526667788", "api.company.com", "5526667788", "yt.com/company" }
                });

            migrationBuilder.InsertData(
                schema: "ECPrivate",
                table: "LocalizationStrings",
                columns: new[] { "Key", "Language", "Value" },
                values: new object[,]
                {
                    { "hello", (byte)0, "Hello" },
                    { "hello", (byte)1, "Merhaba" }
                });

            migrationBuilder.InsertData(
                schema: "ECOption",
                table: "Options",
                columns: new[] { "IsRelease", "EmailVerificationTimeoutMinutes", "IsAdminOpen", "IsOpen", "PagingProductCount", "PasswordResetTimeoutMinutes", "ProductCommentImageLimit", "ProductImageLimit", "RequireLowerCaseInPassword", "RequireNumberInPassword", "RequireSpecialCharacterInPassword", "RequireUpperCaseInPassword", "SelectedCurrency", "ShowStock" },
                values: new object[,]
                {
                    { false, 30, true, true, (byte)20, 30, (byte)5, (byte)10, false, false, false, false, "Lira", false },
                    { true, 30, true, true, (byte)20, 30, (byte)5, (byte)10, false, false, false, false, "Lira", false }
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Permissions",
                columns: new[] { "Id", "IsValid", "Memo", "Name" },
                values: new object[,]
                {
                    { 1, true, null, "AdminUpdate" },
                    { 2, true, null, "AdminDelete" },
                    { 3, true, null, "AdminGet" },
                    { 4, true, null, "AdminGetAll" },
                    { 5, true, null, "AdminAdd" },
                    { 6, true, null, "AnnouncementUpdate" },
                    { 7, true, null, "AnnouncementDelete" },
                    { 8, true, null, "AnnouncementAdd" },
                    { 9, true, null, "AnnouncementEnable" },
                    { 10, true, null, "AnnouncementDisable" },
                    { 11, true, null, "CategoryAdd" },
                    { 12, true, null, "CategoryUpdate" },
                    { 13, true, null, "CategoryDelete" },
                    { 14, true, null, "CategoryEnable" },
                    { 15, true, null, "CategoryDisable" },
                    { 16, true, null, "SubCategoryEnable" },
                    { 17, true, null, "SubCategoryDisable" },
                    { 18, true, null, "CompanyInfoAdd" },
                    { 19, true, null, "CompanyInfoUpdate" },
                    { 20, true, null, "ImageUpload" },
                    { 21, true, null, "OptionGet" },
                    { 22, true, null, "OptionUpdate" },
                    { 23, true, null, "CargoOptionGet" },
                    { 24, true, null, "CargoOptionUpdate" },
                    { 25, true, null, "CargoOptionDelete" },
                    { 26, true, null, "PaymentOptionGet" },
                    { 27, true, null, "PaymentOptionUpdate" },
                    { 28, true, null, "PaymentOptionDelete" },
                    { 29, true, null, "SmtpOptionGet" },
                    { 30, true, null, "SmtpOptionUpdate" },
                    { 31, true, null, "SmtpOptionDelete" }
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Roles",
                columns: new[] { "Id", "IsValid", "Name" },
                values: new object[,]
                {
                    { 1, true, "Owner" },
                    { 2, true, "Admin" },
                    { 3, true, "Moderator" }
                });

            migrationBuilder.InsertData(
                schema: "ECPrivate",
                table: "Users",
                columns: new[] { "Id", "CitizenShipNumber", "Culture", "DeletedDate", "EmailAddress", "FirstName", "IsEmailVerified", "IsValid", "LastName", "OAuthKey", "OAuthType", "Password", "PhoneNumber", "RegisterDate", "TaxNumber", "TwoFactorKey", "TwoFactorType" },
                values: new object[,]
                {
                    { 1, null, "tr", null, "debug@mail.com", "User", false, true, "Last", null, null, "25f9e794323b453885f5181f1b624d0b", "5525553344", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)0 },
                    { 2, null, "tr", null, "debug2@mail.com", "User", false, true, "Last", null, null, "25f9e794323b453885f5181f1b624d0b", "5525553344", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)0 }
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Admins",
                columns: new[] { "Id", "DeletedDate", "EmailAddress", "IsValid", "Password", "RegisterDate", "RoleId", "TwoFactorKey", "TwoFactorType" },
                values: new object[,]
                {
                    { 1, null, "owner@mail.com", true, "25f9e794323b453885f5181f1b624d0b", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, (byte)0 },
                    { 2, null, "admin@mail.com", true, "25f9e794323b453885f5181f1b624d0b", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, (byte)0 },
                    { 3, null, "mod@admin.com", true, "25f9e794323b453885f5181f1b624d0b", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, (byte)0 }
                });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "PermissionRoles",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                schema: "ECPrivate",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminLogs_AdminId",
                schema: "ECLog",
                table: "AdminLogs",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                schema: "ECOperation",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOptions_ImageId",
                schema: "ECOption",
                table: "CargoOptions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                schema: "ECPrivate",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameKey_ParentNameKey",
                schema: "ECPrivate",
                table: "Categories",
                columns: new[] { "NameKey", "ParentNameKey" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDiscounts_CategoryNameKey",
                schema: "ECPrivate",
                table: "CategoryDiscounts",
                column: "CategoryNameKey");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionProducts_CollectionId",
                schema: "ECPrivate",
                table: "CollectionProducts",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                schema: "ECPrivate",
                table: "Collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCoupons_DiscountCategoryNameKey",
                schema: "ECPrivate",
                table: "DiscountCoupons",
                column: "DiscountCategoryNameKey");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountNotifies_ProductId",
                schema: "ECPrivate",
                table: "DiscountNotifies",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifyTokens_UserId",
                schema: "ECPrivate",
                table: "EmailVerifyTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                schema: "ECPrivate",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCouponId",
                schema: "ECPrivate",
                table: "Orders",
                column: "DiscountCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                schema: "ECPrivate",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "ECPrivate",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                schema: "ECPrivate",
                table: "PasswordResetTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_PermissionId",
                schema: "ECOperation",
                table: "PermissionRoles",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId",
                schema: "ECPrivate",
                table: "ProductComments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_UserId",
                schema: "ECPrivate",
                table: "ProductComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                schema: "ECPrivate",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageId",
                schema: "ECPrivate",
                table: "ProductImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductVariantId",
                schema: "ECPrivate",
                table: "Products",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShowCases_ProductId",
                schema: "ECPrivate",
                table: "ProductShowCases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCaseImages_ImageId",
                schema: "ECPrivate",
                table: "ShowCaseImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_ImageId",
                schema: "ECPrivate",
                table: "Sliders",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_ProductId",
                schema: "ECPrivate",
                table: "StockChanges",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_SupplierId",
                schema: "ECPrivate",
                table: "StockChanges",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_UserId",
                schema: "ECPrivate",
                table: "StockChanges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserId",
                schema: "ECLog",
                table: "UserLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "AdminLogs",
                schema: "ECLog");

            migrationBuilder.DropTable(
                name: "Announcements",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "CargoOptions",
                schema: "ECOption");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "CategoryDiscounts",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "CollectionProducts",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "CompanyInformations",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "DiscountNotifies",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "EmailVerifyTokens",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "FavoriteProducts",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "LocalizationStrings",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "ECOption");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "PaymentOptions",
                schema: "ECOption");

            migrationBuilder.DropTable(
                name: "PermissionRoles",
                schema: "ECOperation");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "ProductComments",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "ProductDetails",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "ProductImages",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "ProductShowCases",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "SecurityLogs",
                schema: "ECLog");

            migrationBuilder.DropTable(
                name: "ShowCaseImages",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Sliders",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "SmtpOptions",
                schema: "ECOption");

            migrationBuilder.DropTable(
                name: "StockChanges",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "UserLogs",
                schema: "ECLog");

            migrationBuilder.DropTable(
                name: "Admins",
                schema: "ECOperation");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "DiscountCoupons",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "ECOperation");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "ECOperation");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "ProductVariants",
                schema: "ECPrivate");
        }
    }
}
