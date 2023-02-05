using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasMe.Extensions;
using Azure.Core;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ECom.WebApi.Filters
{
    internal class ExceptionHandleFilter : IExceptionFilter
    {
        private static readonly EasLog logger = EasLogFactory.CreateLogger(nameof(ExceptionHandleFilter));

        public void OnException(ExceptionContext context)
        {
            var query = context.HttpContext.Request.QueryString;
			logger.Exception(context.Exception, $"Query({query})");
			context.HttpContext.Response.StatusCode = 500;

            var type = context.Exception.GetType();
            var baseType = type.BaseType;   
            if (type.Equals(typeof(NotAuthorizedException))) 
			{
				context.HttpContext.Response.StatusCode = 403;
                //Logging 
			}
            if(baseType is not null)
            {
                if (baseType.Equals(typeof(CustomException)))
                {
                    var errCode = type.Name.Replace("Exception", "");
                    var paramArray = context.Exception.Message.Split(':').ToArray();
                    var body = Result.Error(100, errCode, paramArray);
                    context.Result = new BadRequestObjectResult(body);
                    logger.Warn(query, body.ErrorCode,body.Parameters);
                }
            }
           
        }

    }
}
