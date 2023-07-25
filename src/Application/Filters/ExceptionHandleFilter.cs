﻿using ECom.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.Application.Filters;

public class ExceptionHandleFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context) {
    var query = context.HttpContext.Request.QueryString;
    context.HttpContext.Response.StatusCode = 500;

    var type = context.Exception.GetType();
    if (type == typeof(NotAuthorizedException)) {
      context.HttpContext.Response.StatusCode = 403;
      //Logging 
    }
    else {
      context.Result = new ObjectResult(DomainResult.Exception(context.Exception, "ExceptionFilter"));
      context.HttpContext.Response.StatusCode = 500;
      Log.Fatal(context.Exception, $"Query({query})");
    }
  }
}