using Microsoft.AspNetCore.Http.Extensions;

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
			await _next(context);
			var responseStatus = context.Response.StatusCode;
			var fullUrl = context.Request.GetDisplayUrl();
			if(responseStatus == 200)
			{
				logger.Info(responseStatus, fullUrl);
			}
			else
			{
				logger.Error(responseStatus, fullUrl);
			}
		}
	}
}
