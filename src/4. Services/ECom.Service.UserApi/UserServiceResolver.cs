using ECom.Business.Services.UserServices;

namespace ECom.Service.UserApi;

public static class UserServiceResolver
{
  public const string DocName = "UserApi";
  public const string DocTitle = "User API";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
    builder.Services.AddScoped<IUserAccountService, UserAccountService>();
    builder.Services.AddScoped<IUserAddressService, UserAddressService>();
  }

  public static void SetupApplication(WebApplication app) { }
}