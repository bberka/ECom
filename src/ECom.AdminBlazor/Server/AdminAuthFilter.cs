using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.AdminBlazor.Server;

public class AdminAuthFilterAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context) {
    var authorized = context.HttpContext.IsAdminAuthenticated();
    if (!authorized) context.Result = new UnauthorizedObjectResult(DomainResult.Unauthorized());
  }
}