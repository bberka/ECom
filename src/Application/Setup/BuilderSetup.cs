using ECom.Application.Validators;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace ECom.Application.Setup;

public static class BuilderSetup
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  //public static WebApplicationBuilder AddApplicationControllers(this WebApplicationBuilder builder) {
  //  var assembly = typeof(_SharedEndpointsAssembly).Assembly;

  //  builder.Services
  //    .AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); })
  //    .ConfigureApiBehaviorOptions(
  //      options => {
  //        options.InvalidModelStateResponseFactory = c => {
  //          var firstModelTypeName = c.ActionDescriptor.Parameters.FirstOrDefault()?.ParameterType.Name ?? "N/A";
  //          var errors = c.ModelState.Values
  //            .Where(v => v.Errors.Count > 0)
  //            .SelectMany(v => v.Errors)
  //            .Select(v => v.ErrorMessage)
  //            .ToArray();
  //          return new BadRequestObjectResult(DomainResult.Validation(firstModelTypeName, errors.FirstOrDefault()));
  //        };
  //      })
  //    .AddApplicationPart(assembly)
  //    .AddControllersAsServices();
  //  return builder;
  //}


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

  public static WebApplicationBuilder AddDbDependencies(this WebApplicationBuilder builder) {
    builder.Services.AddDbContext<EComDbContext>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    return builder;
  }


  public static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder) {
    ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddScoped<IValidationService, ValidationService>();
    builder.Services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
    builder.Services.AddTransient<IValidator<RegisterUserRequest>, RegisterValidator>();
    builder.Services.AddTransient<IValidator<AddAdminRequest>, AddAdminRequestValidator>();
    builder.Services.AddTransient<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
    builder.Services.AddTransient<IValidator<UpdateAdminAccountRequest>, UpdateAdminAccountRequestValidator>();
    return builder;
  }
}