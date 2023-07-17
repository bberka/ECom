using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Builder;

namespace ECom.Application.Setup;


public class DbEnsureSetup : IApplicationSetup
{
  [InitializeOrder(int.MaxValue)]
  public void InitializeApplication(WebApplication app) {
    EComDbContext.EnsureCreatedAndUpdated();
  }
}