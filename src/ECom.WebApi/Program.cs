
using ECom.Application.DependencyResolvers.AspNetCore;
using ECom.Application.Validators;
using ECom.WebApi.Filters;
using ECom.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
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




#region Session-Memory
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(720);
	options.Cookie.HttpOnly = true;
	// Make the session cookie essential
	options.Cookie.IsEssential = true;
	options.Cookie.Name = ".Session.ECom";	

});
builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();
builder.Services.AddDistributedMemoryCache();

#endregion


builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();


#region Authentication
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
	
});

if (ConstantMgr.isUseJwtAuth)
{
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
}



#endregion

ValidatorOptions.Global.LanguageManager = new ValidationLanguageManager();
builder.Services.AddFluentValidationAutoValidation();




builder.Services.AddBusinessDependencies();


var app = builder.Build();
//ServiceProviderProxy.This.Load(app.Services);

#region Default
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
	
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseCookiePolicy();
app.UseRouting();

#endregion

#region Custom Middlewares

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<MaintenanceCheckMiddleware>();

#endregion

if (ConstantMgr.isUseJwtAuth)
{
	app.UseAuthentication();
	app.UseAuthorization();
}



app.MapControllers();

EComDbContext.EnsureCreated();
app.Run();

EasLogFactory.StaticLogger.Info("Exiting...");