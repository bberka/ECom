﻿using ECom.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.Application.Filters;

public class UserAuthFilterAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context) {
    var authorized = context.HttpContext.IsUserAuthenticated();
    if (!authorized) context.Result = new UnauthorizedObjectResult(Result.Unauthorized());
  }
}