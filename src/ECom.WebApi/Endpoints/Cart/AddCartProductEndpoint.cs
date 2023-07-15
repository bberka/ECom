using ECom.Domain.Results;

namespace ECom.WebApi.Endpoints.Cart;

[AllowAnonymous]
[EndpointRoute(typeof(AddCartProductEndpoint))]
public class AddCartProductEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public AddCartProductEndpoint(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(AddCartProductEndpoint),"Adds product to cart")]
  public override Result Handle(int id) {
    if(HttpContext.IsUserAuthenticated()) {
      var userId = HttpContext.GetUserId();
      var res = _cartService.AddOrIncreaseProduct(userId, id);
      _logService.UserLog(res, userId, "Cart.AddOrIncreaseProduct", id);
      return res;
    }
    HttpContext.AddOrIncreaseInCart(id);
    return DomainResult.Cart.AddProductSuccessResult();
  }
}