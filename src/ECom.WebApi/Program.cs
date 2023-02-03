
using ECom.Application.DependencyResolvers.AspNetCore;
using ECom.Application.Validators;
using ECom.WebApi.Filters;
using ECom.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

EasLogFactory.LoadConfig_TraceDefault(true);

var builder = WebApplication.CreateBuilder(args);

AppDomain.CurrentDomain.AddUnexpectedExceptionHandling();
builder.Services.AddControllers(x =>
{
	x.Filters.Add(new ExceptionHandleFilter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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
            IssuerSigningKey = new SymmetricSecurityKey("vztgffzaoyszvahsacfqxxjvtvbbrnbdtrxwarveycuwpyhkrtuhgkimowfuoiitubvvfedfuqkeztjbbkaapbgsuxcvcjrwxgegdedonqvguuputqqjcmznmqojbjvv".ConvertToByteArray()),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("AdminOnly"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserOnly"));
});

#endregion

ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
builder.Services.AddFluentValidationAutoValidation();

#region Session-Memory
builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();
builder.Services.AddDistributedMemoryCache();

#endregion


builder.Services.AddBusinessDependencies();


var app = builder.Build();
//ServiceProviderProxy.This.Load(app.Services);

#region Default
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
	
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseCookiePolicy();

#endregion

#region Custom Middlewares

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<MaintenanceCheckMiddleware>();
app.UseMiddleware<AuthMiddleware>();

#endregion

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

