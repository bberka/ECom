using ECom.Application.SetupMiddleware;
using ECom.Application.Validators;
using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.DTOs.UserDTOs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.Setup;

public class FluentValidationSetup : IBuilderServiceSetup
{

  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
    services.AddFluentValidationAutoValidation();
    services.AddScoped<IValidationService, ValidationService>();
    services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
    services.AddTransient<IValidator<RegisterUserRequest>, RegisterValidator>();
    services.AddTransient<IValidator<AddAdminRequest>, AddAdminRequestValidator>();
    services.AddTransient<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
    services.AddTransient<IValidator<UpdateAdminAccountRequest>, UpdateAdminAccountRequestValidator>();
  }
}