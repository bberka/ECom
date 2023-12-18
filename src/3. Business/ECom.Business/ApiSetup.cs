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

public static class ApiSetup
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public static void InjectDbDependency(this IServiceCollection services, IConfiguration configuration) {
    services.AddDbContext<EComDbContext>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
  }

  public static void InjectAdminBusinessDependency(this IServiceCollection services, IConfiguration configuration) {
    services.AddScoped<IAdminAccountService, AdminAccountService>();
    services.AddScoped<IAdminRoleService, AdminRoleService>();
    services.AddScoped<IAdminManageService, AdminManageService>();
    services.AddScoped<IAdminCompanyInformationService, AdminCompanyInformationService>();
    services.AddScoped<IAdminImageService, AdminImageService>();
    services.AddScoped<IAdminOptionService, AdminOptionService>();
    services.AddScoped<IAdminCategoryService, AdminCategoryService>();
    services.AddScoped<IAdminAnnouncementService, AdminAnnouncementService>();

    services.AddScoped<IAdminPaymentOptionService, AdminPaymentOptionService>();
    services.AddScoped<IAdminSmtpOptionService, AdminSmtpOptionService>();
    services.AddScoped<IAdminCargoOptionService, AdminCargoOptionService>();
    services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
  }

  public static void InjectUserBusinessDependency(this IServiceCollection services, IConfiguration configuration) {
    services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
    services.AddScoped<IUserAccountService, UserAccountService>();
    services.AddScoped<IUserAddressService, UserAddressService>();
  }

  public static void InjectBaseBusinessDependency(this IServiceCollection services, IConfiguration configuration) {
    services.AddScoped<ILogService, LogService>();
    services.AddScoped<IDebugService, DebugService>();
    services.AddScoped<IOptionService, OptionService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ICompanyInformationService, CompanyInformationService>();
    services.AddScoped<IImageService, ImageService>();
    services.AddScoped<IAnnouncementService, AnnouncementService>();
    services.AddScoped<IPaymentOptionService, PaymentOptionService>();
    services.AddScoped<ISmtpOptionService, SmtpOptionService>();
    services.AddScoped<ICargoOptionService, CargoOptionService>();
    services.AddScoped<IProductService, ProductService>();
  }


  public static void InjectValidators(this IServiceCollection services, IConfiguration configuration) {
    ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
    services.AddFluentValidationAutoValidation();
    services.AddScoped<IValidationService, ValidationService>();
    services.AddScoped<IValidationService, ValidationService>();
    services.AddTransient<IValidator<Request_Login>, LoginValidator>();
    services.AddTransient<IValidator<Request_User_Register>, RegisterValidator>();
    services.AddTransient<IValidator<Request_Admin_Add>, AddAdminRequestValidator>();
    services.AddTransient<IValidator<Request_Password_Change>, ChangePasswordRequestValidator>();
    services.AddTransient<IValidator<Request_Admin_UpdateAccount>, UpdateAdminAccountRequestValidator>();
  }

  // public static void InjectAutoMapper(this IServiceCollection services, IConfiguration configuration) {
  //   services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
  // }

  public static void InjectSwagger(this IServiceCollection services, IConfiguration configuration) {
    services.AddSwaggerGen(c => {
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
    services.AddSwaggerGen(c => { c.EnableAnnotations(); });
  }

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
}