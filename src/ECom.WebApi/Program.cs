using ECom.Application.DependencyResolvers;
using ECom.Application.Middlewares;
using ECom.Application.Validators;
using ECom.Domain;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

EComLoggerHelper.Configure(true);


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersConfigured();
builder.Services.AddSessionConfigured();
builder.Services.AddHttpContextAccessor();
builder.Services.AddResponseCaching();
builder.Services.AddSwaggerConfigured();
builder.Services.AddSwaggerGen(c => {
  c.EnableAnnotations();
});
builder.Services.AddCors();
builder.Services.AddAuthorizationConfigured();

builder.Services.AddDataBaseAccessServices();
builder.Services.AddBusinessLogicServices();


ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
builder.Services.AddBusinessValidators();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddBusinessAuthenticators();
builder.Services.AddAutoMapperConfigured();
//builder.Services
//  .AddHttpLogging(options => {
//    options.LoggingFields = HttpLoggingFields.All;
//    options.RequestBodyLogLimit = 4096;
//    options.ResponseBodyLogLimit = 4096;
//    options.MediaTypeOptions.Clear();
//    options.MediaTypeOptions.AddText("application/json");
//  });

var app = builder.Build();

#region Default

app.UseSwagger();
app.UseSwaggerUI(
//  c => {
//  // Configure the Swagger endpoint for each group
//  c.SwaggerEndpoint("/swagger/User/swagger.json", "User API v1.0");
//  c.SwaggerEndpoint("/swagger/Admin/swagger.json", "Admin API v1.0");

//  // Set the default Swagger UI route
//  c.RoutePrefix = "swagger";
//}
  );
//app.UseSwaggerUI();
//app.UseHttpLogging();

if (app.Environment.IsDevelopment()) {
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
  .SetIsOriginAllowed(origin => true)); // Allow any origin  

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<MaintenanceCheckMiddleware>();

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();


app.MapControllers();


EComDbContext.EnsureCreatedAndUpdated();
app.Run();