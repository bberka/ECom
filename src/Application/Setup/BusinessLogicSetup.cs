using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.Setup;

public class BusinessLogicSetup : IBuilderServiceSetup
{
  [InitializeOrder(5)]
  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.AddDbContext<EComDbContext>();
    services.AddScoped<IOptionService, OptionService>();
    services.AddScoped<ICompanyInformationService, CompanyInformationService>();
    services.AddScoped<IImageService, ImageService>();
    services.AddScoped<IAnnouncementService, AnnouncementService>();
    services.AddScoped<ISliderService, SliderService>();
    services.AddScoped<ILogService, LogService>();
    services.AddScoped<IDiscountService, DiscountService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IAdminService, AdminService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<IAddressService, AddressService>();
    services.AddScoped<IEmailService, EmailService>();
    services.AddScoped<IOrderService, OrderService>();
    services.AddScoped<ICollectionService, CollectionService>();
    services.AddScoped<ICartService, CartService>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IFavoriteProductService, FavoriteProductService>();
    services.AddScoped<IRoleService, RoleService>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IDebugService, DebugService>();
    services.AddScoped<ILocalizationService, LocalizationService>();
  }
}