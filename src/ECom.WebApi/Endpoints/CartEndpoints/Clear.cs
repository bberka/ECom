using ECom.Application.Attributes;
using ECom.Domain;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(Clear))]
public class Clear : EndpointBaseSync.WithoutRequest.WithResult<CustomResult>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public Clear(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(Clear),"Clears cart")]
  public override CustomResult Handle() {
    if (HttpContext.IsUserAuthenticated()) {
      var userId = HttpContext.GetUserId();
      var res = _cartService.ClearCartProducts(userId);
      _logService.UserLog(res, userId, "Cart.Clear");
      return res;
    }
    HttpContext.ClearCart();
    return DomainResult.OkCleared(nameof(Cart));
  }
}