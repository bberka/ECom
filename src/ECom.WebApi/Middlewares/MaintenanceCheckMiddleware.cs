

namespace ECom.WebApi.Middlewares
{
	public class MaintenanceCheckMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IOptionService _optionService;

		public MaintenanceCheckMiddleware(RequestDelegate next,IOptionService optionService)
		{
			_next = next;
			this._optionService = optionService;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			string url = context.Request.Path.ToString();
			if (url.Contains("Admin"))
			{
				if (!_optionService.GetFromCache().IsAdminOpen)
				{
					context.Response.StatusCode = 503;
					return;
				}
			}
			else
			{
				var isUserAdmin = context.User?.HasClaim(x => x.Subject?.Name == "AdminOnly");
				if (!_optionService.GetFromCache().IsOpen && isUserAdmin == false)
				{
					context.Response.StatusCode = 503;
					return;
				}
			}
			
			await _next(context);
		}
	}
}
