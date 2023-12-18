using System.Text;
using AspNetCore.Authorization.Extender;
using ECom.Business.Filters;
using ECom.Business.Services;
using ECom.Business.Services.AdminServices;
using ECom.Business.Services.BaseServices;
using ECom.Business.Services.UserServices;
using ECom.Business.Validators;
using ECom.Database;
using ECom.Foundation.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ECom.Business;

public static class BusinessResolver
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public static void SetupBuilder(WebApplicationBuilder builder) {
    ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddScoped<IValidationService, ValidationService>();
    builder.Services.AddScoped<IValidationService, ValidationService>();
    builder.Services.AddTransient<IValidator<Request_Login>, LoginValidator>();
    builder.Services.AddTransient<IValidator<Request_User_Register>, RegisterValidator>();
    builder.Services.AddTransient<IValidator<Request_Admin_Add>, AddAdminRequestValidator>();
    builder.Services.AddTransient<IValidator<Request_Password_Change>, ChangePasswordRequestValidator>();
    builder.Services.AddTransient<IValidator<Request_Admin_UpdateAccount>, UpdateAdminAccountRequestValidator>();
  }

  // public static void InjectAutoMapper(this IServiceCollection services, IConfiguration configuration) {
  //   services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
  // }


  public static void InjectAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration) {
    services.AddAuthentication(op => {
              op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("Bearer", token => {
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
    services.AddAuthorization(options => {
      options.AddPolicy(EComClaimTypes.AdminPolicy, policy => policy.RequireClaim(EComClaimTypes.AdminClaimType));
      options.AddPolicy(EComClaimTypes.UserPolicy, policy => policy.RequireClaim(EComClaimTypes.UserClaimType));
    });
    var dictionary = new Dictionary<object, object>();
    var permissions = Enum.GetNames(typeof(AdminPermissionType));
    foreach (var permission in permissions) dictionary.Add(permission, permission);

    services.AddAuthorization(x => { x.AddRequiredPermissionPolicies(dictionary); });
  }

  public static WebApplicationBuilder AddApplicationControllers(this WebApplicationBuilder builder) {
    // var assembly = typeof(Status).Assembly;

    builder.Services
           .AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); })
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
  public static void SetupApplication(WebApplication app) { }
}