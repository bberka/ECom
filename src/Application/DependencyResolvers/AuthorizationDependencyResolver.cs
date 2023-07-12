using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace ECom.Application.DependencyResolvers;

public static class AuthorizationDependencyResolver
{
  public static IServiceCollection AddAuthorizationConfigured(this IServiceCollection services) {
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
#if DEBUG
        token.RequireHttpsMetadata = false;
#endif
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
    return services;
  }
}