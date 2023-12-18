namespace ECom.Service.UserApi.Controllers.CartEndpoints;

public class Clear : EndpointBaseSync.WithoutRequest.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public Clear(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/cart/clear", HttpMethodType.POST)]
  [OpenApiOperation("Cart")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result Handle() {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = _cartService.ClearCartProducts(userId);
      _logService.UserLog(UserActionType.ClearCart, res, userId);
      return res;
    }

    HttpContext.ClearCart();
    return DefResult.OkCleared(nameof(Cart));
  }
}