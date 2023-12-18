using System.Text;
using AspNetCore.Authorization.Extender;
using ECom.Business.Filters;
using ECom.Business.Services;
using ECom.Business.Validators;
using ECom.Foundation.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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


  public static void SetupApplication(WebApplication app) { }
}