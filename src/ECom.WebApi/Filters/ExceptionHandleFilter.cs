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

			//var userId = context.HttpContext.User.GetUserId();
			//if(userId != 0)
			//{
			//    logger.Exception(context.Exception, $"AdminNo:{userId} Query({query})");
			//    context.ExceptionHandled = true;
			//    var message = Regex.Replace(context.Exception.Message, @"[^\u0000-\u007F]+", string.Empty).RemoveLineEndings();
			//    context.HttpContext.Response.Redirect("/Home/ErrorPage?message=" + message);
			//}
			//else
			//{
			//    logger.Exception(context.Exception, $"Query({query})");
			//    context.ExceptionHandled = true;
			//    context.HttpContext.Response.StatusCode = 500;
			//}
		}
	}
}
