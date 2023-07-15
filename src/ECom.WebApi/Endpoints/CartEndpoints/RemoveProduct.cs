using ECom.Application.Attributes;
using ECom.Domain.Results;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(RemoveProduct))]
public class RemoveProduct : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public RemoveProduct(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(RemoveProduct),"Removes product from cart")]
  public override Result Handle(int id) {
    if (HttpContext.IsUserAuthenticated()) {
      var userId = HttpContext.GetUserId();
      var res = _cartService.RemoveOrDecreaseProduct(userId, id);
      _logService.UserLog(res, userId, "Cart.RemoveOrDecreaseProduct", id);
      return res;
    }
    HttpContext.RemoveOrDecreaseInCart(id);
    return DomainResult.Cart.RemoveProductSuccessResult();
  }
}