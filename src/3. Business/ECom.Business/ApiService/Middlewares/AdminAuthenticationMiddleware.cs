using ECom.Business.ApiService.Abstract;

namespace ECom.Business.ApiService.Middlewares;

public class AdminAuthenticationMiddleware
{
  private readonly RequestDelegate _next;

  public AdminAuthenticationMiddleware(RequestDelegate next) {
    _next = next;
  }

  public async Task Invoke(HttpContext context) {
    var endpoint = context.GetEndpoint();
    if (endpoint != null && endpoint.Metadata.GetMetadata<IAdminAuthEndpoint>() != null)
      if (!context.HasClaim(EComClaimTypes.AdminClaimType)) {
        context.Response.StatusCode = 403; // Forbidden
        return;
      }

    await _next(context);
  }
}