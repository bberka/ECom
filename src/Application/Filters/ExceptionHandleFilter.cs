﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace ECom.Application.Filters;

public class ExceptionHandleFilter : IExceptionFilter
{

  public void OnException(ExceptionContext context) {
    var query = context.HttpContext.Request.QueryString;
    context.HttpContext.Response.StatusCode = 500;

    var type = context.Exception.GetType();
    if (type.Equals(typeof(NotAuthorizedException))) {
      context.HttpContext.Response.StatusCode = 403;
      //Logging 
    }
    else {
      context.Result = new ObjectResult(Result.Error(context.Exception.Message));
      context.HttpContext.Response.StatusCode = 500;
      Log.Fatal(context.Exception, $"Query({query})");
    }
    //if(baseType is not null)
    //{
    //    if (baseType.Equals(typeof(CustomException)))
    //    {
    //        var errCode = type.Name.Replace("Exception", "");
    //        var paramArray = context.Exception.Message.Split(':').ToArray();
    //        var body = Result.Error(100, errCode, paramArray);
    //        context.Result = new OkObjectResult(body);
    //        logger.Warn(query, body.ErrorCode,body.Parameters);
    //    }
    //}
  }
}