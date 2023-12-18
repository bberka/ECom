using ECom.Business.Services.AdminServices;
using ECom.Foundation.Abstract.Services.Admin;

namespace ECom.Service.AdminApi;

public static class AdminServiceResolver
{
  public const string DocName = "AdminApi";
  public const string DocTitle = "Admin Endpoints";

  public const string DocUrl = "/doc/admin";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IAdminAccountService, AdminAccountService>();
    builder.Services.AddScoped<IAdminRoleService, AdminRoleService>();
    builder.Services.AddScoped<IAdminManageService, AdminManageService>();
    builder.Services.AddScoped<IAdminCompanyInformationService, AdminCompanyInformationService>();
    builder.Services.AddScoped<IAdminImageService, AdminImageService>();
    builder.Services.AddScoped<IAdminOptionService, AdminOptionService>();
    builder.Services.AddScoped<IAdminCategoryService, AdminCategoryService>();
    builder.Services.AddScoped<IAdminAnnouncementService, AdminAnnouncementService>();

    builder.Services.AddScoped<IAdminPaymentOptionService, AdminPaymentOptionService>();
    builder.Services.AddScoped<IAdminSmtpOptionService, AdminSmtpOptionService>();
    builder.Services.AddScoped<IAdminCargoOptionService, AdminCargoOptionService>();
    builder.Services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
  }

  public static void SetupApplication(WebApplication app) { }
}