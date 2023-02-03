
namespace ECom.WebApi.Middlewares
{
    public class AuthMiddleware
    {

        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Session.GetString("token");
            if (token != null)
            {
				context.Request.Headers.Add("Authorization", "Bearer " + token);
			}
            await _next(context);
		}
      
    }

}
