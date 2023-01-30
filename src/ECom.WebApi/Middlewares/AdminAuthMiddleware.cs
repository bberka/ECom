namespace MoonApp.Middleware
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
           

		}
      

    }

}
