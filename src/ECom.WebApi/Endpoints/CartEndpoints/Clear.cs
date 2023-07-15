using ECom.Application.Attributes;
using ECom.Domain.Results;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(Clear))]
public class Clear : EndpointBaseSync.WithoutRequest.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public Clear(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(Clear),"Clears cart")]
  public override Result Handle() {
    if (HttpContext.IsUserAuthenticated()) {
      var userId = HttpContext.GetUserId();
      var res = _cartService.Clear(userId);
      _logService.UserLog(res, userId, "Cart.Clear");
      return res;
    }
    HttpContext.ClearCart();
    return DomainResult.Cart.ClearSuccessResult();
  }
}