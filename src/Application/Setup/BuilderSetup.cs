using System.Text;
using ECom.Application.Filters;
using ECom.Application.Manager;
using ECom.Application.SharedEndpoints;
using ECom.Application.Validators;
using ECom.Domain;
using ECom.Domain.Lib;
using ECom.Shared.Constants;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace ECom.Application.Setup;

public static class BuilderSetup
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public static WebApplicationBuilder AddApplicationControllers(this WebApplicationBuilder builder) {
    var assembly = typeof(_SharedEndpointsAssembly).Assembly;

    builder.Services
      .AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); })
      .ConfigureApiBehaviorOptions(
        options => {
          options.InvalidModelStateResponseFactory = c => {
            var firstModelTypeName = c.ActionDescriptor.Parameters.FirstOrDefault()?.ParameterType.Name ?? "N/A";
            var errors = c.ModelState.Values
              .Where(v => v.Errors.Count > 0)
              .SelectMany(v => v.Errors)
              .Select(v => v.ErrorMessage)
              .ToArray();
            return new BadRequestObjectResult(DomainResult.Validation(firstModelTypeName, errors.FirstOrDefault()));
          };
        })
      .AddApplicationPart(assembly)
      .AddControllersAsServices();
    return builder;
  }


  public static WebApplicationBuilder AddAuthenticationPolicies(this WebApplicationBuilder builder) {
    builder.Services
      .AddAuthentication(op => {
        op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer("Bearer", token => {
        if (ConstantMgr.IsDevelopment())
          token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(JwtOption.This.Secret)),
          ValidateIssuer = JwtOption.This.ValidateIssuer,
          ValidateAudience = JwtOption.This.ValidateAudience,
          RequireExpirationTime = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };
      });

    builder.Services.AddAuthorization(options => {
      options.AddPolicy("AdminOnly", policy => policy.RequireClaim("AdminOnly"));
      options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserOnly"));
    });
    return builder;
  }


  public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder) {
    builder.Services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
    builder.Services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
    builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
    builder.Services.AddDbContext<EComDbContext>();
    builder.Services.AddScoped<IOptionService, OptionService>();
    builder.Services.AddScoped<ICompanyInformationService, CompanyInformationService>();
    builder.Services.AddScoped<IImageService, ImageService>();
    builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
    builder.Services.AddScoped<ISliderService, SliderService>();
    builder.Services.AddScoped<ILogService, LogService>();
    builder.Services.AddScoped<IDiscountService, DiscountService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IAdminService, AdminService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IAddressService, AddressService>();
    builder.Services.AddScoped<IEmailService, EmailService>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<ICollectionService, CollectionService>();
    builder.Services.AddScoped<ICartService, CartService>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IFavoriteProductService, FavoriteProductService>();
    builder.Services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IDebugService, DebugService>();
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