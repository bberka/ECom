

namespace ECom.WebApi.Middlewares
{
	public class MaintenanceCheckMiddleware
	{
		private readonly RequestDelegate _next;

		public MaintenanceCheckMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IOptionService optionService)
		{
			string url = context.Request.Path.ToString();
			if (url.Contains("Admin"))
			{
				if (!optionService.GetOptionFromCache().IsAdminOpen)
				{
					context.Response.StatusCode = 503;
					return;
				}
			}
			else
			{
				var isUserAdmin = context.User?.HasClaim(x => x.Subject?.Name == "AdminOnly");
				if (!optionService.GetOptionFromCache().IsOpen && isUserAdmin == false)
				{
					context.Response.StatusCode = 503;
					return;
				}
			}
			
			await _next(context);
		}
	}
}
