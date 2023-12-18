using ECom.Business.ApiService.Abstract;

namespace ECom.Business.ApiService.Middlewares;

public class UserAuthenticationMiddleware
{
  private readonly RequestDelegate _next;

  public UserAuthenticationMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task Invoke(HttpContext context) {
    var endpoint = context.GetEndpoint();
    if (endpoint != null && endpoint.Metadata.GetMetadata<IUserAuthEndpoint>() != null)
      if (!context.HasClaim(EComClaimTypes.UserClaimType)) {
        context.Response.StatusCode = 403; // Forbidden
        return;
      }

    await _next(context);
  }
}