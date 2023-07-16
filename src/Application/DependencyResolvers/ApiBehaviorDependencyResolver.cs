using ECom.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Application.DependencyResolvers;

public static class ApiBehaviorDependencyResolver
{
  public static IServiceCollection AddControllersConfigured(this IServiceCollection services) {
    services.AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); }).ConfigureApiBehaviorOptions(
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
          return new BadRequestObjectResult(DomainResult.Validation(firstModelTypeName,errors));
        };
      });
    services.AddEndpointsApiExplorer();
    return services;
  }
}