using AspNetCore.Authorization.Extender;
using Bers.Blazor.Ext.Javascript;
using Blazored.SessionStorage;
using ECom.AdminBlazorServer.Common;
using ECom.Application.Filters;
using ECom.Application.Setup;
using ECom.Domain;
using ECom.Shared;
using ECom.Shared.Constants;
using ECom.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Radzen;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);

// BASE SERVICES
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<HttpClient>();
//builder.Services.AddAuthenticationCore();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredSessionStorage();
//builder.AddAuthenticationPolicies();

// This needs to be setup after setting up Blazor
//builder.Services.AddAuthentication(x => {
//  x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//  x.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//  x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//  x.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;

//}).AddCookie();
//builder.Services.AddAuthenticationCore();
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
  })
  .AddCookie();

var dictionary = new Dictionary<object, object>();
var permissions = Enum.GetNames(typeof(AdminPermission));
foreach (var permission in permissions) {
  dictionary.Add(permission, permission);
}
builder.Services.AddAuthorization(x => {
  x.AddRequiredPermissionPolicies(dictionary);
});
//builder.Services.AddScoped<ProtectedSessionStorage>();
//builder.Services.AddScoped<ProtectedBrowserStorage>();
builder.Services.AddScoped<ProtectedLocalStorage>();

builder.Services.AddScoped<AuthenticationStateProvider, AdminAuthenticationStateProvider>();
builder.Services.AddScoped<RevalidatingServerAuthenticationStateProvider, AdminAuthenticationStateProvider>();
//builder.Services.AddScoped<AdminAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationService>();

//builder.Services.AddSingleton<LoginStateCacheProvider>();
//RADZEN SERVICES

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();


//AUTH SERVICES

//builder.Services.AddScoped<IAdminAuthenticationStateProvider,AdminAuthenticationStateProvider>();


//LOCALIZATION
builder.Services.AddLocalization(x => {
  x.ResourcesPath = "Resources";
});

var cultures = builder.Configuration.GetSection("Cultures")
  .GetChildren()
  .ToDictionary(x => x.Key, x => x.Value);
var supportedCulture = new SupportedCultures {
  Dictionary = cultures
};
builder.Services.AddSingleton(supportedCulture);
var supportedCultureKeys = cultures.Keys.ToArray();
var localizationOptions = new RequestLocalizationOptions()
  //.SetDefaultCulture(supportedCultureKeys[0])
  .AddSupportedCultures(supportedCultureKeys)
  .AddSupportedUICultures(supportedCultureKeys);

//builder.Configuration.Bind("AppSettings", new AppSettings());
//builder.Services.AddSingleton<AppSettings>();


//SHARED BASE SERVICES
builder.Services.AddOptions();
//builder.AddApplicationControllers();
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
    });
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddHttpContextAccessor();

builder.Services.AddResponseCaching(); //useless in blazor
builder.Services.AddCors();

//COOKIE
builder.Services.AddCookiePolicy(x => {
  //x.Secure = CookieSecurePolicy.Always;
  x.MinimumSameSitePolicy = SameSiteMode.None;
  //x.HttpOnly = HttpOnlyPolicy.Always;
  x.CheckConsentNeeded = context => false;
});
builder.Services.ConfigureApplicationCookie(options => {
  options.Cookie.HttpOnly = true;
  options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
  options.LoginPath = "/";
  options.AccessDeniedPath = "/AccessDenied";
  options.SlidingExpiration = true;
});
builder.Services.AddSession(options => {
  options.IdleTimeout = TimeSpan.FromMinutes(JwtOption.This.SessionExpireMinutes);
  options.Cookie.HttpOnly = true;
  // Make the session cookie essential
  options.Cookie.IsEssential = true;
  options.Cookie.Name = ".Session.ECom";
});
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();

builder.Services.Configure<CookiePolicyOptions>(options => {
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});
//--END Cookie
//Application project services
builder.AddApplicationServices();
//builder.AddAuthenticationPolicies();
builder.AddValidators();


builder.Services.AddSwaggerGen(c => {
  c.DocInclusionPredicate((groupName, apiDescription) => {
    if (apiDescription.GroupName == null || apiDescription.GroupName == groupName) return true;
    return false;
  });
});
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

builder.Services.AddBlazorExt();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseCookiePolicy();

app.UseCors(x => x
  .AllowAnyMethod()
  .AllowAnyHeader()
  .AllowCredentials()
  //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
  .SetIsOriginAllowed(origin => true)); // Allow any origin  


app.UseRequestLocalization(localizationOptions);



app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();