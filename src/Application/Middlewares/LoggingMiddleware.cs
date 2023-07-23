using System.Diagnostics;

namespace ECom.Application.Middlewares;

public class LoggingMiddleware
{
  private readonly RequestDelegate _next;

  public LoggingMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context) {
    var timer = new Stopwatch();
    timer.Start();
    await _next(context);
    timer.Stop();
    var responseStatus = context.Response.StatusCode;
    //var fullUrl = context.Request.GetRequestQuery();
    var authLogString = "No-Auth";
    //TODO log user id
    //if (context.IsUserAuthenticated()) authLogString = $"User({context.GetUserId()})";
    //if (context.IsAdminAuthenticated()) authLogString = $"Admin({context.GetAdminId()})";
    Log.Information("Request Log: {ResponseStatus} {Auth} {TimeElapsed}", responseStatus, authLogString,
      $"TimeElapsed({timer.ElapsedMilliseconds}ms)");
  }
}