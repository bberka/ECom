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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
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
                    NameKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ParentNameKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.NameKey);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInformation",
                schema: "ECOperation",
                columns: table => new
                {
                    Key = table.Column<bool>(type: "bit", nullable: false),
                    DomainUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    WebApiUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    LogoImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FavIcoImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformation", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCoupons",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<float>(type: "real", nullable: false),
                    Coupon = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCoupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "ECOption",
                columns: table => new
                {
                    Key = table.Column<bool>(type: "bit", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    RequireUpperCaseInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireLowerCaseInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireSpecialCharacterInPassword = table.Column<bool>(type: "bit", nullable: false),
                    RequireNumberInPassword = table.Column<bool>(type: "bit", nullable: false),
                    EmailVerificationTimeoutMinutes = table.Column<int>(type: "int", nullable: false),
                    PasswordResetTimeoutMinutes = table.Column<int>(type: "int", nullable: false),
                    DefaultCurrency = table.Column<int>(type: "int", nullable: false),
                    ShowStock = table.Column<bool>(type: "bit", nullable: false),
                    PagingProductCount = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductImageLimit = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductCommentImageLimit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                schema: "ECOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "ECPrivate",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HttpStatusCode = table.Column<short>(type: "smallint", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    XReal_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CFConnecting_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RequestUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    QueryString = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Host = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CitizenShipNumber = table.Column<int>(type: "int", nullable: true),
                    TaxNumber = table.Column<int>(type: "int", nullable: true),
                    OAuthKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OAuthType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    TwoFactorKey = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    TwoFactorType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    Culture = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    RefreshJwtToken = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<float>(type: "real", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDiscounts_Categories_CategoryId",
                        column: x => x.CategoryId,
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FreeShippingMinCost = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Sliders",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountedPriceIncludingTax = table.Column<float>(type: "real", nullable: false),
                    OriginalPriceIncludingTax = table.Column<float>(type: "real", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    ProductVariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    TwoFactorKey = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TwoFactorType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    RoleId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RefreshJwtToken = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
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
                    RoleId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => new { x.RoleId, x.Permission });
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Provience = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifyTokens", x => x.Id);
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ECPrivate",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "ECPrivate",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountedPrice = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Star = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DescriptionMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalInformationMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "ShowCases",
                schema: "ECPrivate",
                columns: table => new
                {
                    ShowCaseType = table.Column<byte>(type: "tinyint", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCases", x => x.ShowCaseType);
                    table.ForeignKey(
                        name: "FK_ShowCases_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "ECPrivate",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowCases_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ECPrivate",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StockChanges",
                schema: "ECPrivate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Level = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    OperationName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Params = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HttpStatusCode = table.Column<short>(type: "smallint", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    XReal_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CFConnecting_IpAddress = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RequestUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    QueryString = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                schema: "ECOperation",
                table: "CompanyInformation",
                columns: new[] { "Key", "CompanyAddress", "CompanyName", "ContactEmail", "Description", "DomainUrl", "FacebookLink", "FavIcoImageId", "InstagramLink", "LogoImageId", "PhoneNumber", "WebApiUrl", "WhatsApp", "YoutubeLink" },
                values: new object[] { true, "Addresses", "CompanyName", "contact@support.com", "Company Description", "www.company.com", "facebook.com/company", null, "instagram.com/company", null, "5526667788", "api.company.com", "5526667788", "yt.com/company" });

            migrationBuilder.InsertData(
                schema: "ECOption",
                table: "Options",
                columns: new[] { "Key", "DefaultCurrency", "EmailVerificationTimeoutMinutes", "IsOpen", "PagingProductCount", "PasswordResetTimeoutMinutes", "ProductCommentImageLimit", "ProductImageLimit", "RequireLowerCaseInPassword", "RequireNumberInPassword", "RequireSpecialCharacterInPassword", "RequireUpperCaseInPassword", "ShowStock" },
                values: new object[] { true, 0, 30, true, (byte)20, 30, (byte)5, (byte)10, false, false, false, false, false });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Roles",
                column: "Id",
                value: "owner");

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "Admins",
                columns: new[] { "Id", "DeleteDate", "EmailAddress", "Password", "RefreshJwtToken", "RegisterDate", "RoleId", "TwoFactorKey", "UpdateDate" },
                values: new object[] { new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"), null, "owner@mail.com", "25f9e794323b453885f5181f1b624d0b", null, new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "owner", null, null });

            migrationBuilder.InsertData(
                schema: "ECOperation",
                table: "PermissionRoles",
                columns: new[] { "Permission", "RoleId" },
                values: new object[,]
                {
                    { 0, "owner" },
                    { 1, "owner" },
                    { 2, "owner" },
                    { 3, "owner" },
                    { 4, "owner" },
                    { 5, "owner" },
                    { 6, "owner" },
                    { 7, "owner" },
                    { 8, "owner" },
                    { 9, "owner" },
                    { 10, "owner" },
                    { 11, "owner" },
                    { 12, "owner" },
                    { 13, "owner" },
                    { 14, "owner" },
                    { 15, "owner" },
                    { 16, "owner" },
                    { 17, "owner" },
                    { 18, "owner" },
                    { 19, "owner" },
                    { 20, "owner" },
                    { 21, "owner" },
                    { 22, "owner" }
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
                name: "IX_CategoryDiscounts_CategoryId",
                schema: "ECPrivate",
                table: "CategoryDiscounts",
                column: "CategoryId");

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
                name: "IX_DiscountCoupons_Coupon",
                schema: "ECPrivate",
                table: "DiscountCoupons",
                column: "Coupon");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountNotifies_ProductId",
                schema: "ECPrivate",
                table: "DiscountNotifies",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifyTokens_Token",
                schema: "ECPrivate",
                table: "EmailVerifyTokens",
                column: "Token");

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
                name: "IX_PasswordResetTokens_Token",
                schema: "ECPrivate",
                table: "PasswordResetTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                schema: "ECPrivate",
                table: "PasswordResetTokens",
                column: "UserId");

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
                name: "IX_ShowCases_ImageId",
                schema: "ECPrivate",
                table: "ShowCases",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCases_ProductId",
                schema: "ECPrivate",
                table: "ShowCases",
                column: "ProductId");

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
                name: "CompanyInformation",
                schema: "ECOperation");

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
                name: "SecurityLogs",
                schema: "ECLog");

            migrationBuilder.DropTable(
                name: "ShowCases",
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
                name: "Admins",
                schema: "ECOperation");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "ECPrivate");

            migrationBuilder.DropTable(
                name: "DiscountCoupons",
                schema: "ECPrivate");

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
                name: "ProductVariants",
                schema: "ECPrivate");
        }
    }
}
