using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasMe.Extensions;
using Azure.Core;
using System.Text.RegularExpressions;

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

			if(context.Exception.GetType().Equals(typeof(NotAuthorizedException))) 
			{
				context.HttpContext.Response.StatusCode = 403;
			}
			
		}
	}
}
