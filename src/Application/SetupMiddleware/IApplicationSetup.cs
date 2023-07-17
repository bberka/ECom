using Microsoft.AspNetCore.Builder;

namespace ECom.Application.SetupMiddleware;

public interface IApplicationSetup
{
  /// <summary>
  ///   This is where you can add any app setup
  /// </summary>
  /// <param name="app"></param>
  void InitializeApplication(WebApplication app);
}