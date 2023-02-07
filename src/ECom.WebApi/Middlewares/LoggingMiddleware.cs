using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;
using EasMe.Logging;

namespace ECom.WebApi.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EasLog logger = EasLogFactory.CreateLogger(nameof(LoggingMiddleware));
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var timer = new Stopwatch();
            timer.Start();
            await _next(context);
            timer.Stop();
            var responseStatus = context.Response.StatusCode;
            var fullUrl = context.Request.GetRequestQuery();
            var authLogString = "No-Auth";
            if (context.IsUserAuthenticated())
            {
                authLogString = $"User({context.GetUserId()})";
            }
            if (context.IsAdminAuthenticated())
            {
                
                authLogString = $"Admin({context.GetAdminId()})";
            }

            if (responseStatus == 200)
            {
                logger.Info(responseStatus, fullUrl, authLogString, $"TimeElapsed({timer.ElapsedMilliseconds}ms)");
            }
            else
            {
                logger.Error(responseStatus, fullUrl, authLogString, $"TimeElapsed({timer.ElapsedMilliseconds}ms)");
            }
        }
    }
}
