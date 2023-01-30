using System.Net;
using System.Security.Claims;
using System.Text;

namespace MoonApp.Middleware
{
    public class UserAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            

		}

    }

}
