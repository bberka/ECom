using System.Text;
using AspNetCore.Authorization.Extender;
using ECom.Business.Filters;
using ECom.Foundation.Lib;
using ECom.Foundation.Models;
using ECom.Foundation.Static;
using ECom.Service.AdminApi;
using ECom.Service.PublicApi;
using ECom.Service.UserApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

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
    if (DomAppSettings.This.EnableSwagger || app.Environment.IsDevelopment()) {
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
                           if (StaticValues.IsDevelopment)
                             token.RequireHttpsMetadata = false;
                           token.SaveToken = true;
                           token.TokenValidationParameters = new TokenValidationParameters {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(DomAppSettings.This.JwtSecret)),
                             ValidateIssuer = DomAppSettings.This.JwtValidateIssuer,
                             ValidateAudience = DomAppSettings.This.JwtValidateAudience,
                             RequireExpirationTime = true,
                             ValidateLifetime = true,
                             ClockSkew = TimeSpan.Zero
                           };
                         });

    builder.Services.AddAuthorization(options => {
      options.AddPolicy(DomClaimTypes.AdminPolicy, policy => policy.RequireClaim(DomClaimTypes.AdminClaimType));
      options.AddPolicy(DomClaimTypes.UserPolicy, policy => policy.RequireClaim(DomClaimTypes.UserClaimType));
    });
    var dictionary = new Dictionary<object, object>();
    var permissions = Enum.GetNames(typeof(AdminPermissionType));
    foreach (var permission in permissions) dictionary.Add(permission, permission);

    builder.Services.AddAuthorization(x => { x.AddRequiredPermissionPolicies(dictionary); });
  }

  public static WebApplicationBuilder ConfigureApplicationControllers(this WebApplicationBuilder builder) {
    builder.Services
           .AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); })
           .AddApplicationPart(typeof(AdminServiceResolver).Assembly)
           .AddApplicationPart(typeof(UserServiceResolver).Assembly)
           .AddApplicationPart(typeof(PublicServiceResolver).Assembly)
           .ConfigureApiBehaviorOptions(
                                        options => { options.InvalidModelStateResponseFactory = c => { return new BadRequestObjectResult(DomResults.validation_error(c.ModelState)); }; })
           // .AddApplicationPart(assembly)
           .AddControllersAsServices();
    return builder;
  }
}