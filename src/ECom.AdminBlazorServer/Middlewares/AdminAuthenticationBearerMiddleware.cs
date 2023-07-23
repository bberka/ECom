namespace ECom.AdminBlazorServer.Middlewares;

public class AdminAuthenticationBearerMiddleware
{
  private readonly RequestDelegate _next;

  public AdminAuthenticationBearerMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context) {
    var token = context.Session.GetString("token");
    if (!string.IsNullOrEmpty(token)) context.Request.Headers["Authorization"] = $"Bearer {token}";
    await _next(context);
  }
}