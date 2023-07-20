using ECom.Application.Middlewares;
using ECom.Application.Setup;
using ECom.WebApi.Middlewares;
using Microsoft.OpenApi.Models;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);

//builder.Setup();
builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECom.WebApi", Version = "v1" });
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
    Description = @$"JWT Authorization header using the Bearer scheme. 
                        {Environment.NewLine}{Environment.NewLine}Enter 'Your token in the text input below.
                      {Environment.NewLine}{Environment.NewLine}Example: '12345abcdef'",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer"
  });
  c.SwaggerDoc("User", new OpenApiInfo { Title = "User API", Version = "v1" });
  c.SwaggerDoc("Admin", new OpenApiInfo { Title = "Admin API", Version = "v1" });
  c.DocInclusionPredicate((groupName, apiDescription) => {
    // Filter the API descriptions based on the group name
    if (apiDescription.GroupName == null || apiDescription.GroupName == groupName) return true;
    return false;
  });
  c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

var app = builder.Build();

app.UseMiddleware<DebugUserAuthenticationMiddleware>();

//app.Setup();
app.Run();