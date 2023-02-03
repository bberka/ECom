using Microsoft.AspNetCore.Mvc.Filters;

namespace ECom.WebApi.Filters
{
	public class ValidationFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				var errorsInModelState = context.ModelState
					.Where(x => x.Value?.Errors.Count > 0)
					.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

				ErrorResponse errorReponse = new ErrorResponse();

				foreach (var error in errorsInModelState)
				{
					foreach (var subError in error.Value )
					{
						ErrorModel errorModel = new ErrorModel
						{
							FieldName = error.Key,
							Message = subError
						};

						errorReponse.Errors.Add(errorModel);
					}
				}

				context.Result = new BadRequestObjectResult(ResultData<ErrorResponse>.Error(400,ErrCode.ValidationError));
				return;
			}

			await next();
		}
	}
}
