namespace ECom.Service.UserApi.CartEndpoints;

public class RemoveProduct : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public RemoveProduct(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/cart/remove-product", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Cart")]
  public override Result Handle(Guid id) {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = _cartService.RemoveOrDecreaseProduct(userId, id);
      _logService.UserLog(UserActionType.RemoveOrDecreaseProductFromCart, res, userId, id);
      return res;
    }

    HttpContext.RemoveOrDecreaseInCart(id);
    return DefResult.OkRemoved(nameof(Cart));
  }
}