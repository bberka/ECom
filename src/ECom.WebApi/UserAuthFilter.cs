using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.WebApi;

public class UserAuthFilterAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context) {
    var authorized = context.HttpContext.IsUserAuthenticated();
    if (!authorized) context.Result = new UnauthorizedObjectResult(DomainResult.Unauthorized());
  }
}