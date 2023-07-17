using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.SetupMiddleware;

public interface IBuilderServiceSetup
{
  /// <summary>
  ///   This is where you can add any service setup
  /// </summary>
  /// <param name="services"></param>
  void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host);
}