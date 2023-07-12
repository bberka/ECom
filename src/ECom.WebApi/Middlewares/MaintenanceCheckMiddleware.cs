namespace ECom.WebApi.Middlewares;

public class MaintenanceCheckMiddleware
{
  private readonly RequestDelegate _next;

  public MaintenanceCheckMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context, IOptionService optionService) {
    var url = context.Request.Path.ToString();
    if (url.Contains("Admin")) {
      if (!optionService.GetOption().IsAdminOpen) {
        context.Response.StatusCode = 503;
        return;
      }
    }
    else {
      var isUserAdmin = context.User?.HasClaim(x => x.Subject?.Name == "AdminOnly");
      if (!optionService.GetOption().IsOpen && isUserAdmin == false) {
        context.Response.StatusCode = 503;
        return;
      }
    }

    await _next(context);
  }
}