using System.Text;
using ECom.Application.Manager;
using ECom.Application.SetupMiddleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECom.Application.Setup;

public class AuthorizationSetup : IBuilderServiceSetup, IApplicationSetup
{

  public void InitializeServices(IServiceCollection services, ConfigurationManager configuration, ConfigureHostBuilder host) {
    services.Configure<CookiePolicyOptions>(options => {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services
      .AddAuthentication(op => {
        op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer("Bearer", token => {
        if(ConstantMgr.IsDevelopment())
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

    services.AddAuthorization(options => {
      options.AddPolicy("AdminOnly", policy => policy.RequireClaim("AdminOnly"));
      options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserOnly"));
    });
    services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
    services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
  }

  [InitializeOrder(int.MaxValue)]
  public void InitializeApplication(WebApplication app) {
    app.UseAuthentication();
    app.UseAuthorization();
  }
}