namespace ECom.Service.UserApi.CartEndpoints;

public class ListProducts : EndpointBaseSync.WithoutRequest.WithResult<List<Cart>>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public ListProducts(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/cart/list-products", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Cart")]
  public override List<Cart> Handle() {
    if (!HttpContext.IsAuthenticated())
      return HttpContext.GetDbCartEntity(null).ToList();
    var userId = HttpContext.GetAuthId();
    var list = _cartService.ListBasketProducts(userId);
    _logService.UserLog(UserActionType.ListCartProducts, list, userId);
    return list.Data;
  }
}