using ECom.AdminBlazorServer.Data;
using ECom.Application.Manager;
using ECom.Application.Services;
using ECom.Application.Setup;
using ECom.Application.Validators;
using ECom.Domain.Abstract;
using ECom.Domain.Lib;
using ECom.Infrastructure;
using ECom.Shared.DTOs;
using ECom.Shared.DTOs.AdminDto;
using ECom.Shared.DTOs.UserDto;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<HttpClient>();


builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Setup();

//builder.Services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
//builder.Services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();

//builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

//builder.Services.AddDbContext<EComDbContext>();
//builder.Services.AddScoped<IOptionService, OptionService>();
//builder.Services.AddScoped<ICompanyInformationService, CompanyInformationService>();
//builder.Services.AddScoped<IImageService, ImageService>();
//builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
//builder.Services.AddScoped<ISliderService, SliderService>();
//builder.Services.AddScoped<ILogService, LogService>();
//builder.Services.AddScoped<IDiscountService, DiscountService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IAddressService, AddressService>();
//builder.Services.AddScoped<IEmailService, EmailService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<ICollectionService, CollectionService>();
//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IFavoriteProductService, FavoriteProductService>();
//builder.Services.AddScoped<IRoleService, RoleService>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IDebugService, DebugService>();
//builder.Services.AddScoped<ILocalizationService, LocalizationService>();


//ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddScoped<IValidationService, ValidationService>();
//builder.Services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
//builder.Services.AddTransient<IValidator<RegisterUserRequest>, RegisterValidator>();
//builder.Services.AddTransient<IValidator<AddAdminRequest>, AddAdminRequestValidator>();
//builder.Services.AddTransient<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
//builder.Services.AddTransient<IValidator<UpdateAdminAccountRequest>, UpdateAdminAccountRequestValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.Setup();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
