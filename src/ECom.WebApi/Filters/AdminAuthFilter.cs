using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.WebApi.Filters
{
	public class AdminAuthFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var authorized = context.HttpContext.IsAdminAuthorized();
			if(!authorized)
			{
				context.Result = new UnauthorizedObjectResult(Result.Error(401,ErrCode.NotAuthorized));
			}
		}

	}
}
