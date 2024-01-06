using ECom.Foundation.Static;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.Business.Attributes;

public class NotAuthorizedOnly : ActionFilterAttribute
{
  public NotAuthorizedOnly() { }

  public override void OnResultExecuting(ResultExecutingContext context) {
    var isAuthenticated = context.HttpContext.IsAuthenticated();
    if (isAuthenticated) {
      context.Result = new JsonResult(DomResults.already_logged_in());
    }
  }
}