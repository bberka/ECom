using ECom.Business.Services;
using ECom.Business.Services.BaseServices;

namespace ECom.Service.PublicApi;

public static class PublicServiceResolver
{
  public const string DocName = "PublicApi";
  public const string DocTitle = "Public API";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services.AddScoped<ILogService, LogService>();
    builder.Services.AddScoped<IDebugService, DebugService>();
    builder.Services.AddScoped<IOptionService, OptionService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<ICompanyInformationService, CompanyInformationService>();
    builder.Services.AddScoped<IImageService, ImageService>();
    builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
    builder.Services.AddScoped<IPaymentOptionService, PaymentOptionService>();
    builder.Services.AddScoped<ISmtpOptionService, SmtpOptionService>();
    builder.Services.AddScoped<ICargoOptionService, CargoOptionService>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IContentService, ContentService>();
  }

  public static void SetupApplication(WebApplication app) { }
}