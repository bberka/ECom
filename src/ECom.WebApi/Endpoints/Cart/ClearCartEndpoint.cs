using ECom.Domain.Results;

namespace ECom.WebApi.Endpoints.Cart;

[AllowAnonymous]
[EndpointRoute(typeof(ClearCartEndpoint))]
public class ClearCartEndpoint : EndpointBaseSync.WithoutRequest.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public ClearCartEndpoint(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(ClearCartEndpoint),"Clears cart")]
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