using ECom.Business.Services.UserServices;

namespace ECom.Service.UserApi;

public static class UserServiceResolver
{
  public const string DocName = "UserApi";
  public const string DocTitle = "User Endpoints";
  public const string DocUrl = "/doc/user";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
    builder.Services.AddScoped<IUserAccountService, UserAccountService>();
    builder.Services.AddScoped<IUserAddressService, UserAddressService>();
  }

  public static void SetupApplication(WebApplication app) { }
}