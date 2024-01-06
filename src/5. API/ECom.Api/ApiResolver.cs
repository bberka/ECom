using System.Text;
using AspNetCore.Authorization.Extender;
using ECom.Business.Filters;
using ECom.Foundation.Lib;
using ECom.Foundation.Models;
using ECom.Service.AdminApi;
using ECom.Service.PublicApi;
using ECom.Service.UserApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ECom.Api;

public static class ApiResolver
{
  private static readonly string ApiName = "ECom WebApi";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    ConfigureApplicationControllers(builder);
    builder.Services.AddMemoryCache();
    builder.Services.AddEndpointsApiExplorer();

    ConfigureSwagger(builder);
    ConfigureAuthentication(builder);
  }


  public static void SetupApplication(WebApplication app) {
    if (EComAppSettings.This.EnableSwagger || app.Environment.IsDevelopment()) {
      app.UseSwagger(settings => { settings.RouteTemplate = "/swagger/{documentName}/swagger.json"; });
      app.UseSwaggerUI(x => {
        x.SwaggerEndpoint($"/swagger/{AdminServiceResolver.DocName}/swagger.json", AdminServiceResolver.DocTitle);
        x.SwaggerEndpoint($"/swagger/{UserServiceResolver.DocName}/swagger.json", UserServiceResolver.DocTitle);
        x.SwaggerEndpoint($"/swagger/{PublicServiceResolver.DocName}/swagger.json", PublicServiceResolver.DocTitle);
        x.RoutePrefix = "swagger";
      });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
  }

  private static void ConfigureSwagger(WebApplicationBuilder builder) {
    builder.Services.AddSwaggerGen(x => {
      x.SwaggerDoc(AdminServiceResolver.DocName,
                   new OpenApiInfo {
                     Title = AdminServiceResolver.DocTitle,
                     Version = "v1"
                   });

      x.SwaggerDoc(PublicServiceResolver.DocName,
                   new OpenApiInfo {
                     Title = PublicServiceResolver.DocTitle,
                     Version = "v1"
                   });

      x.SwaggerDoc(UserServiceResolver.DocName,
                   new OpenApiInfo {
                     Title = UserServiceResolver.DocTitle,
                     Version = "v1"
                   });

      x.AddSecurityDefinition("Bearer",
                              new OpenApiSecurityScheme {
                                Description = @$"JWT Authorization header using the Bearer scheme. 
                        {Environment.NewLine}{Environment.NewLine}Enter 'Your token in the text input below.
                      {Environment.NewLine}{Environment.NewLine}Example: '12345abcdef'",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.Http,
                                Scheme = "Bearer"
                              });
      x.DocInclusionPredicate((groupName,
                               apiDescription) => {
        if (apiDescription.GroupName == null || apiDescription.GroupName == groupName) return true;
        return false;
      });
      x.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
          new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
            },
            Scheme = "Http",
            Name = "Bearer",
            In = ParameterLocation.Header
          },
          new List<string>()
        }
      });
    });
    builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
  }

  private static void ConfigureAuthentication(WebApplicationBuilder builder) {
    builder.Services.AddAuthentication(op => {
             op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer("Bearer",
                         token => {
                           if (ConstantContainer.IsDevelopment())
                             token.RequireHttpsMetadata = false;
                           token.SaveToken = true;
                           token.TokenValidationParameters = new TokenValidationParameters {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(EComAppSettings.This.JwtSecret)),
                             ValidateIssuer = EComAppSettings.This.JwtValidateIssuer,
                             ValidateAudience = EComAppSettings.This.JwtValidateAudience,
                             RequireExpirationTime = true,
                             ValidateLifetime = true,
                             ClockSkew = TimeSpan.Zero
                           };
                         });

    // services.AddAuthentication(options => {
    //           options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //           options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    //         })
    //         .AddCookie();
    builder.Services.AddAuthorization(options => {
      options.AddPolicy(EComClaimTypes.AdminPolicy, policy => policy.RequireClaim(EComClaimTypes.AdminClaimType));
      options.AddPolicy(EComClaimTypes.UserPolicy, policy => policy.RequireClaim(EComClaimTypes.UserClaimType));
    });
    var dictionary = new Dictionary<object, object>();
    var permissions = Enum.GetNames(typeof(AdminPermissionType));
    foreach (var permission in permissions) dictionary.Add(permission, permission);

    builder.Services.AddAuthorization(x => { x.AddRequiredPermissionPolicies(dictionary); });
  }

  public static WebApplicationBuilder ConfigureApplicationControllers(this WebApplicationBuilder builder) {
    // var assembly = typeof(Status).Assembly;
    builder.Services
           .AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); })
           .AddApplicationPart(typeof(AdminServiceResolver).Assembly)
           .AddApplicationPart(typeof(UserServiceResolver).Assembly)
           .AddApplicationPart(typeof(PublicServiceResolver).Assembly)
           .ConfigureApiBehaviorOptions(
                                        options => {
                                          options.InvalidModelStateResponseFactory = c => {
                                            var firstModelTypeName = c.ActionDescriptor.Parameters.FirstOrDefault()?.ParameterType.Name ?? "N/A";
                                            var errors = new List<Error>();
                                            foreach (var modelState in c.ModelState)
                                            foreach (var error in modelState.Value.Errors) {
                                              var message = error.Exception?.Message ?? error.ErrorMessage;
                                              var propertyName = modelState.Key;
                                              errors.Add(new Error("ValidationFailed",
                                                                   new[] {
                                                                     new LocParam("name", propertyName),
                                                                     new LocParam("errorMessage", message)
                                                                   }));
                                            }

                                            return new BadRequestObjectResult(DefResult.Validation(errors));
                                          };
                                        })
           // .AddApplicationPart(assembly)
           .AddControllersAsServices();
    return builder;
  }


  // public static void InjectAutoMapper(this IServiceCollection services, IConfiguration configuration) {
  //   services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
  // }

//public static WebApplicationBuilder AddAuthenticationPolicies(this WebApplicationBuilder builder) {
//  builder.Services
//    .AddAuthentication(op => {
//      op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//      op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//      op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer("Bearer", token => {
//      if (ConstantMgr.IsDevelopment())
//        token.RequireHttpsMetadata = false;
//      token.SaveToken = true;
//      token.TokenValidationParameters = new TokenValidationParameters {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(JwtOption.This.Secret)),
//        ValidateIssuer = JwtOption.This.ValidateIssuer,
//        ValidateAudience = JwtOption.This.ValidateAudience,
//        RequireExpirationTime = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//      };
//    });

//  builder.Services.AddAuthorization(options => {
//    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("AdminOnly"));
//    options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserOnly"));
//  });
//  return builder;
//}
}