using ECom.Application.Filters;
using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ECom.Application.Setup;


public class ApplicationDefaultSetup : IApplicationSetup, IBuilderServiceSetup
{
  [InitializeOrder(int.MinValue)]
  public void InitializeApplication(WebApplication app) {
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


    app.MapControllers();
  }

  [InitializeOrder(int.MinValue)]
  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.AddControllers(x => {
      x.Filters.Add(new ExceptionHandleFilter()); 

    }).ConfigureApiBehaviorOptions(
      options => {
        options.InvalidModelStateResponseFactory = c => {
          var firstModelTypeName = c.ActionDescriptor.Parameters.FirstOrDefault()?.ParameterType.Name ?? "N/A";
          var errors = c.ModelState.Values
            .Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => new ValidationError() {
              Message = v.ErrorMessage,
              Exception = v.Exception
            })
            .ToArray();
          return new BadRequestObjectResult(DomainResult.Validation(firstModelTypeName, errors));
        };
      });
    services.AddEndpointsApiExplorer();
    services.AddHttpContextAccessor();
    services.AddResponseCaching();
    services.AddCors();
  }
}