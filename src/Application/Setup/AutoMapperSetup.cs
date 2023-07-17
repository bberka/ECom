using ECom.Application.SetupMiddleware;
using ECom.Domain.Lib;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.Setup;


public class AutoMapperSetup : IBuilderServiceSetup
{

  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
  }
}