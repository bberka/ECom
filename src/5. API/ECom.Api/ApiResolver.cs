using System.Reflection;
using ECom.Foundation.Lib;
using ECom.Service.AdminApi;
using ECom.Service.AdminApi.Abstract;
using ECom.Service.PublicApi;
using ECom.Service.PublicApi.Abstract;
using ECom.Service.UserApi;
using ECom.Service.UserApi.Abstract;
using Microsoft.OpenApi.Models;
using Namotion.Reflection;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ECom.Api;

public static class ApiResolver
{
  private readonly static string ApiName = "ECom WebApi";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services
           .AddControllers()
           .AddApplicationPart(typeof(AdminServiceResolver).Assembly)
           .AddApplicationPart(typeof(UserServiceResolver).Assembly)
           .AddApplicationPart(typeof(PublicServiceResolver).Assembly);

    builder.Services.AddMemoryCache();
    builder.Services.AddEndpointsApiExplorer();


    builder.Services.AddOpenApiDocument(document => {
      document.DocumentName = AdminServiceResolver.DocName;
      document.Title = AdminServiceResolver.DocTitle;
      document.AddOperationFilter(x => { return x.ControllerType.IsSubclassOf(typeof(AdminControllerBase)); });
    });

    builder.Services.AddOpenApiDocument(document => {
      document.DocumentName = PublicServiceResolver.DocName;
      document.Title = PublicServiceResolver.DocTitle;
      document.AddOperationFilter(x => { return x.ControllerType.IsSubclassOf(typeof(PublicControllerBase)); });
    });

    builder.Services.AddOpenApiDocument(document => {
      document.DocumentName = UserServiceResolver.DocName;
      document.Title = UserServiceResolver.DocTitle;
      document.AddOperationFilter(x => { return x.ControllerType.IsSubclassOf(typeof(UserControllerBase)); });
    });
  }


  public static void SetupApplication(WebApplication app) {
    var enableSwagger = ConfigLib.GetString("EnableSwagger");
    if (enableSwagger == "true") {
      app.UseOpenApi(settings => { settings.Path = "/swagger/{documentName}/swagger.json"; });

      app.UseReDoc(settings => {
        settings.Path = AdminServiceResolver.DocUrl;
        settings.DocumentPath = $"/swagger/{AdminServiceResolver.DocName}/swagger.json";
      });

      app.UseReDoc(settings => {
        settings.Path = UserServiceResolver.DocUrl;
        settings.DocumentPath = $"/swagger/{UserServiceResolver.DocName}/swagger.json";
      });
      app.UseReDoc(settings => {
        settings.Path = PublicServiceResolver.DocUrl;
        settings.DocumentPath = $"/swagger/{PublicServiceResolver.DocName}/swagger.json";
      });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
  }

  private static void AddSwagger(WebApplicationBuilder builder) {
    builder.Services.AddSwaggerGen(x => {
      x.SwaggerDoc(ApiName, new OpenApiInfo {
        Title = ApiName,
        Version = ConstantContainer.Version,
      });
      x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Description = @$"JWT Authorization header using the Bearer scheme. 
                        {Environment.NewLine}{Environment.NewLine}Enter 'Your token in the text input below.
                      {Environment.NewLine}{Environment.NewLine}Example: '12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
      });
      x.DocInclusionPredicate((groupName, apiDescription) => {
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
}