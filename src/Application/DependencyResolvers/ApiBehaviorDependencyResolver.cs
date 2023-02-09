using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Application.DependencyResolvers
{
    public static class ApiBehaviorDependencyResolver
    {
        public static IServiceCollection AddControllersConfigured(this IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                x.Filters.Add(new ExceptionHandleFilter());
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = c.ModelState.Values
                        .Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToArray();

                    return new BadRequestObjectResult(Result.Error(400, "ValidationError:" + string.Join("|", errors)));
                };
            });
            services.AddEndpointsApiExplorer();
            return services;
        }
    }
}
