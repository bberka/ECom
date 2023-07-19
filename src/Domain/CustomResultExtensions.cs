using Microsoft.AspNetCore.Mvc;

namespace ECom.Domain;

public static class CustomResultExtensions
{
  public  static ActionResult<CustomResult<T>> ToActionResult<T>(this CustomResult<T> result) {
    if (result.Status) return new OkObjectResult(result);
    return new BadRequestObjectResult(result);
  }

  public static ActionResult<CustomResult<T>> ToActionResult<T>(this CustomResult<T> result, int failStatusCode) {
    if (result.Status) return new OkObjectResult(result);
    return new ObjectResult(result) {
      StatusCode = failStatusCode
    };
  }

  public static ActionResult<CustomResult> ToActionResult(this CustomResult result) {
    if (result.Status) return new OkObjectResult(result);
    return new BadRequestObjectResult(result);
  }

  public static ActionResult<CustomResult> ToActionResult(this CustomResult result, int failStatusCode) {
    if (result.Status) return new OkObjectResult(result);
    return new ObjectResult(result) {
      StatusCode = failStatusCode
    };
  }
}