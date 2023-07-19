using System.Text;
using ECom.Application.Filters;
using ECom.Application.Manager;
using ECom.Application.SharedEndpoints.OptionEndpoints;
using ECom.Application.Validators;
using ECom.Domain;
using ECom.Domain.Lib;
using ECom.Shared.Constants;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ECom.Application.Setup;

public static class BuilderSetup
{
  private const int SessionTimeOutSeconds = int.MaxValue;

  public static WebApplicationBuilder Setup(this WebApplicationBuilder builder) {
    builder.Services.AddControllers(x => { x.Filters.Add(new ExceptionHandleFilter()); }).ConfigureApiBehaviorOptions(
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
      });
    var assembly = typeof(GetCargoInfo).Assembly;
    builder.Services.AddControllers().AddApplicationPart(assembly).AddControllersAsServices();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddResponseCaching();
    builder.Services.AddCors();

    builder.Services.AddSession(options => {
      options.IdleTimeout = TimeSpan.FromSeconds(SessionTimeOutSeconds);
      options.Cookie.HttpOnly = true;
      // Make the session cookie essential
      options.Cookie.IsEssential = true;
      options.Cookie.Name = ".Session.ECom";
    });
    builder.Services.AddMemoryCache();
    builder.Services.AddDataProtection();
    builder.Services.AddDistributedMemoryCache();

    builder.Services.Configure<CookiePolicyOptions>(options => {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

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
    builder.Services.AddScoped<ILocalizationService, LocalizationService>();


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