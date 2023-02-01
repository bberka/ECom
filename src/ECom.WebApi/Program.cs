using EasMe;
using EasMe.Extensions;
using ECom.Application.BaseManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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
            IssuerSigningKey = new SymmetricSecurityKey(OptionMgr.This.GetSingle().JwtSecret.ConvertToByteArray()),
            ValidateIssuer = OptionMgr.This.Cache.Get().JwtValidateIssuer,
            ValidateAudience = OptionMgr.This.Cache.Get().JwtValidateAudience,
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

builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();


//app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

