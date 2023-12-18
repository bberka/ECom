using Microsoft.AspNetCore.Mvc;

namespace ECom.Foundation.Extensions;

public static class ResultExtensions
{
  public static ActionResult<Result<T>> ToActionResult<T>(this Result<T> result) {
    if (result.Status) return new OkObjectResult(result);
    return new BadRequestObjectResult(result);
  }

  public static ActionResult<Result<T>> ToActionResult<T>(this Result<T> result, int failStatusCode) {
    if (result.Status) return new OkObjectResult(result);
    return new ObjectResult(result) {
      StatusCode = failStatusCode
    };
  }

  public static ActionResult<Result> ToActionResult(this Result result) {
    if (result.Status) return new OkObjectResult(result);
    return new BadRequestObjectResult(result);
  }

  public static ActionResult<Result> ToActionResult(this Result result, int failStatusCode) {
    if (result.Status) return new OkObjectResult(result);
    return new ObjectResult(result) {
      StatusCode = failStatusCode
    };
  }
}