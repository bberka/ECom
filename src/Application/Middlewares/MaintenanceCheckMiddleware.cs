namespace ECom.Application.Middlewares;

public class MaintenanceCheckMiddleware
{
  private readonly RequestDelegate _next;

  public MaintenanceCheckMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context, IOptionService optionService) {
    var url = context.Request.Path.ToString();
    if (!optionService.GetOption().IsOpen) {
      context.Response.StatusCode = 503;
      return;
    }
    await _next(context);
  }
}