using EasMe.Logging;
using ECom.Application.DependencyResolvers;
using ECom.Application.Validators;
using ECom.Domain.Lib;
using ECom.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

EasLogFactory.LoadConfig_TraceDefault(true);

var builder = WebApplication.CreateBuilder(args);
AppDomain.CurrentDomain.AddUnexpectedExceptionHandling();


builder.Services.AddControllersConfigured();
builder.Services.AddSessionConfigured();
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCaching();
builder.Services.AddSwaggerConfigured();

builder.Services.AddCors();
builder.Services.AddAuthorizationConfigured();

builder.Services.AddBaseDataBaseAccessLayer();
builder.Services.AddBusinessLogicServices();

ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
builder.Services.AddBusinessValidators();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddBusinessAuthenticators();

var app = builder.Build();

#region Default

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{


}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseCookiePolicy();
app.UseRouting();

#endregion

#region Custom Middlewares

app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials()
       //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
       .SetIsOriginAllowed(origin => true));// Allow any origin  

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<MaintenanceCheckMiddleware>();

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();


app.MapControllers();

var list = CommonLib.GetAdminOperationTypes();

EComDbContext.EnsureCreated();
app.Run();

EasLogFactory.StaticLogger.Info("Exiting...");