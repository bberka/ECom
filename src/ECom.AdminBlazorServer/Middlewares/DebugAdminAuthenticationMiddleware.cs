using ECom.Shared.Abstract.Services.Admin;

namespace ECom.AdminBlazorServer.Middlewares;

public class DebugAdminAuthenticationMiddleware
{
  private static string token = "";
  private readonly RequestDelegate _next;

  public DebugAdminAuthenticationMiddleware(
    RequestDelegate next) {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context, IAdminJwtAuthenticator adminJwtAuthenticator,
    IAdminService adminService) {
    await _next(context);


    //if (!ConstantMgr.IsDevelopment()) {
    //  await _next(context);
    //  return;
    //}

    //if (string.IsNullOrEmpty(token)) {
    //  var adminResult = adminService.GetAdmin(1);
    //  if (adminResult.Status) {
    //    var tokenResult = adminJwtAuthenticator.Authenticate(new LoginRequest {
    //      Password = adminResult.OrderedData.Password,
    //      EmailAddress = adminResult.OrderedData.EmailAddress,
    //      IsHashed = true
    //    });
    //    if (tokenResult.Status) token = tokenResult.OrderedData.Token.Token!;
    //    context.Session.SetString("token", token);
    //  }
    //}

    //context.Request.Headers["Authorization"] = $"Bearer {token}";

    //await _next(context);
  }
}