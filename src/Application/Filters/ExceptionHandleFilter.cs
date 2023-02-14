﻿using EasMe.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.Application.Filters
{
    public class ExceptionHandleFilter : IExceptionFilter
    {
        private static readonly IEasLog logger = EasLogFactory.CreateLogger();

        public void OnException(ExceptionContext context)
        {
            var query = context.HttpContext.Request.QueryString;
			context.HttpContext.Response.StatusCode = 500;

            var type = context.Exception.GetType();
            if (type.Equals(typeof(NotAuthorizedException))) 
			{
				context.HttpContext.Response.StatusCode = 403;
                //Logging 
			}
            else
            {
                context.Result = new ObjectResult(Result.Error(100, context.Exception.Message));
                context.HttpContext.Response.StatusCode = 500;
                logger.Exception(context.Exception, $"Query({query})");
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
}
