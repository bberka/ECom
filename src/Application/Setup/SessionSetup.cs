using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.Setup;

public class SessionSetup : IBuilderServiceSetup
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.AddSession(options => {
      options.IdleTimeout = TimeSpan.FromSeconds(SessionTimeOutSeconds);
      options.Cookie.HttpOnly = true;
      // Make the session cookie essential
      options.Cookie.IsEssential = true;
      options.Cookie.Name = ".Session.ECom";
    });
    services.AddMemoryCache();
    services.AddDataProtection();
    services.AddDistributedMemoryCache();
  }
}