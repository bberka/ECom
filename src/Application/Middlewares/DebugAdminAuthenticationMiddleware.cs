using Microsoft.AspNetCore.Http;
using Serilog;
using System.Diagnostics;

namespace ECom.Application.Middlewares;

public class DebugAdminAuthenticationMiddleware
{
  private readonly RequestDelegate _next;

  public DebugAdminAuthenticationMiddleware(
    RequestDelegate next) {
    _next = next;
  }

  private static string token = "";
  public async Task InvokeAsync(HttpContext context, IAdminJwtAuthenticator adminJwtAuthenticator, IAdminService adminService) {
    if (!ConstantMgr.IsDevelopment()) {
      await _next(context);
      return;
    }
    if (string.IsNullOrEmpty(token)) {
      var adminResult = adminService.GetAdmin(1);
      if (adminResult.Status) {
        var tokenResult = adminJwtAuthenticator.Authenticate(new LoginRequest() {
          Password = adminResult.Data.Password,
          EmailAddress = adminResult.Data.EmailAddress,
          IsHashed = true
        });
        if (tokenResult.Status) {
          token = tokenResult.Data.Token.Token!;
        }
      }
    }
    context.Request.Headers["Authorization"] = $"Bearer {token}";

    await _next(context);
  }
}