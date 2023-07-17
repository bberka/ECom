using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ECom.AdminApi.Setup;

public class AdminAuthorizationSetup : IBuilderServiceSetup
{
  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.AddControllers(config => {
      var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
      config.Filters.Add(new AuthorizeFilter(policy));
    });
  }
}