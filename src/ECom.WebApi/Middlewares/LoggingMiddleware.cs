using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;

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
            User? user = null;
            Admin? admin = null;
            if (context.IsUserAuthenticated())
            {
                user = context.GetUser();
            }
            if (context.IsAdminAuthenticated())
            {
                admin = context.GetAdmin();
            }
            var authLogString = $"User({user?.Id}):Admin({admin?.Id})";

            if (responseStatus == 200)
            {
                logger.Info(responseStatus, fullUrl, authLogString, "Time elapsed: " + timer.ElapsedMilliseconds + " ms");
            }
            else
            {
                logger.Error(responseStatus, fullUrl, authLogString, "Time elapsed: " + timer.ElapsedMilliseconds + " ms");
            }
        }
    }
}
