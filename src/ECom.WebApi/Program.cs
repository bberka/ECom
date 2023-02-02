using EasMe;
using EasMe.Extensions;
using ECom.Application.DependencyResolvers.AspNetCore;
using ECom.Application.DependencyResolvers.Ninject;
using ECom.Infrastructure;
using ECom.WebApi.Filters;
using ECom.WebApi.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Reflection;



EasLogFactory.LoadConfig_TraceDefault(true);

var builder = WebApplication.CreateBuilder(args);

#region Exception Handling
AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
{
    try
    {
        EasLogFactory.StaticLogger.Exception((Exception?)e.ExceptionObject ?? new Exception("FATAL|EXCEPTION IS NULL"), "UnhandledException");
    }
    catch (Exception)
    {
        EasLogFactory.StaticLogger.Fatal(e.ToJsonString(), "UnhandledException");
    }
};
builder.Services.AddControllers(x =>
{
	x.Filters.Add(new ExceptionHandleFilter());
});
#endregion



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
            IssuerSigningKey = new SymmetricSecurityKey(OptionDal.This.GetSingle().JwtSecret.ConvertToByteArray()),
            ValidateIssuer = OptionDal.This.Cache.Get().JwtValidateIssuer,
            ValidateAudience = OptionDal.This.Cache.Get().JwtValidateAudience,
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



#region Session-Memory
builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();
builder.Services.AddDistributedMemoryCache();

#endregion


builder.Services.AddBusinessDependencies();

var app = builder.Build();


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

app.UseMiddleware<AdminAuthMiddleware>();

#endregion

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

