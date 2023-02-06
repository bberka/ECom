
using ECom.Application.DependencyResolvers.AspNetCore;
using ECom.Application.Validators;
using ECom.WebApi.Filters;
using ECom.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;

EasLogFactory.LoadConfig_TraceDefault(true);

var builder = WebApplication.CreateBuilder(args);

AppDomain.CurrentDomain.AddUnexpectedExceptionHandling();
builder.Services.AddControllers(x =>
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

        return new BadRequestObjectResult(Result.Error(400, ErrorCode.ValidationError, errors));
    };
});

builder.Services.AddEndpointsApiExplorer();


#region Session-Memory
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(720);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".Session.ECom";

});
builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();
builder.Services.AddDistributedMemoryCache();

#endregion


builder.Services.AddHttpContextAccessor();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ECom.WebApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @$"JWT Authorization header using the Bearer scheme. 
                        {Environment.NewLine}{Environment.NewLine}Enter 'Your token in the text input below.
                      {Environment.NewLine}{Environment.NewLine}Example: '12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "Http",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
});

builder.Services.AddCors();

#region Authentication
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services
.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer", token =>
{
#if DEBUG
    token.RequireHttpsMetadata = false;
#endif
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(JwtOption.This.Secret.ConvertToByteArray()),
        ValidateIssuer = JwtOption.This.ValidateIssuer,
        ValidateAudience = JwtOption.This.ValidateAudience,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("AdminOnly"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserOnly"));
});


#endregion

ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();


builder.Services.AddBusinessDependencies();

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

#region Default

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{


}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseCookiePolicy();
app.UseRouting();

#endregion

#region Custom Middlewares

app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials()
       //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
       .SetIsOriginAllowed(origin => true));// Allow any origin  

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<MaintenanceCheckMiddleware>();

#endregion

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

EComDbContext.EnsureCreated();
app.Run();

EasLogFactory.StaticLogger.Info("Exiting...");