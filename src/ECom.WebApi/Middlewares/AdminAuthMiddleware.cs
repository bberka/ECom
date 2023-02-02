
namespace ECom.WebApi.Middlewares
{
    public class AdminAuthMiddleware
    {

        private readonly RequestDelegate _next;

        public AdminAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Session.GetString("admin-token");
            if (token != null)
            {
				context.Request.Headers.Add("Authorization", "Bearer " + token);
			}
            await _next(context);
		}
      
    }

}
