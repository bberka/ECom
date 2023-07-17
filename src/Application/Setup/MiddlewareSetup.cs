using ECom.Application.Middlewares;
using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Builder;

namespace ECom.Application.Setup;

public class MiddlewareSetup : IApplicationSetup
{
  [InitializeOrder(10)]
  public void InitializeApplication(WebApplication app) {
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<MaintenanceCheckMiddleware>();

  }
}