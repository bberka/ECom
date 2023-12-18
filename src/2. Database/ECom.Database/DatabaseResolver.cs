using ECom.Foundation.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Database;

public static class DatabaseResolver
{
  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services.AddDbContext<EComDbContext>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
  }

  public static void SetupApplication(WebApplication app) { }
}