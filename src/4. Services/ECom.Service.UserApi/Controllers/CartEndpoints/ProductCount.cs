namespace ECom.Service.UserApi.Controllers.CartEndpoints;

public class ProductCount : EndpointBaseSync.WithoutRequest.WithResult<int>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public ProductCount(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/cart/product-count", HttpMethodType.GET)]
  [OpenApiOperation("Cart")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override int Handle() {
    if (!HttpContext.IsAuthenticated()) return HttpContext.GetCart().Count;
    var userId = HttpContext.GetAuthId();
    var count = _cartService.GetBasketProductCount(userId);
    _logService.UserLog(UserActionType.GetCartProductCount, userId, count);
    return count;
  }
}