using ECom.Foundation.Lib;
using ECom.Service.AdminApi;
using ECom.Service.PublicApi;
using ECom.Service.UserApi;
using Microsoft.OpenApi.Models;

namespace ECom.Api;

public static class ApiResolver
{
  private static readonly string ApiName = "ECom WebApi";

  public static void SetupBuilder(WebApplicationBuilder builder) {
    builder.Services
           .AddControllers()
           .AddApplicationPart(typeof(AdminServiceResolver).Assembly)
           .AddApplicationPart(typeof(UserServiceResolver).Assembly)
           .AddApplicationPart(typeof(PublicServiceResolver).Assembly);

    builder.Services.AddMemoryCache();
    builder.Services.AddEndpointsApiExplorer();


    AddSwagger(builder);
  }


  public static void SetupApplication(WebApplication app) {
    var enableSwagger = ConfigLib.GetString("EnableSwagger");
    if (enableSwagger == "true") {
      app.UseSwagger(settings => { settings.RouteTemplate = "/swagger/{documentName}/swagger.json"; });
      app.UseSwaggerUI(x => {
        x.SwaggerEndpoint($"/swagger/{AdminServiceResolver.DocName}/swagger.json", AdminServiceResolver.DocTitle);
        x.SwaggerEndpoint($"/swagger/{UserServiceResolver.DocName}/swagger.json", UserServiceResolver.DocTitle);
        x.SwaggerEndpoint($"/swagger/{PublicServiceResolver.DocName}/swagger.json", PublicServiceResolver.DocTitle);


        x.RoutePrefix = "swagger";
        x.DefaultModelsExpandDepth(-1);
      });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
  }

  private static void AddSwagger(WebApplicationBuilder builder) {
    builder.Services.AddSwaggerGen(x => {
      x.SwaggerDoc(AdminServiceResolver.DocName, new OpenApiInfo {
        Title = AdminServiceResolver.DocTitle,
        Version = "v1"
      });

      x.SwaggerDoc(PublicServiceResolver.DocName, new OpenApiInfo {
        Title = PublicServiceResolver.DocTitle,
        Version = "v1"
      });

      x.SwaggerDoc(UserServiceResolver.DocName, new OpenApiInfo {
        Title = UserServiceResolver.DocTitle,
        Version = "v1"
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