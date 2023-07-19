using System.Reflection;
using ECom.Application.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace ECom.Application.Setup;

public static class ApplicationSetup
{
  public static WebApplication Setup(this WebApplication app) {
    if (app.Environment.IsDevelopment()) {
    }

    //app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseSession();
    app.UseCookiePolicy();
    app.UseRouting();
    app.UseCors(x => x
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials()
      //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
      .SetIsOriginAllowed(origin => true)); // Allow any origin  


    app.UseResponseCaching();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
    var callingAssembly = Assembly.GetCallingAssembly();
    var isAdminApi = callingAssembly.FullName!.Contains("AdminBlazor.Server");
    var isWebApi = callingAssembly.FullName!.Contains("WebApi");
    if (isAdminApi)
      app.UseMiddleware<DebugAdminAuthenticationMiddleware>();
    else if (isWebApi) app.UseMiddleware<DebugUserAuthenticationMiddleware>();


    app.UseAuthentication();
    app.UseAuthorization();


    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<MaintenanceCheckMiddleware>();

    //EComDbContext.EnsureCreatedAndUpdated();
    return app;
  }
}