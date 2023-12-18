namespace ECom.Service.UserApi.Controllers.CartEndpoints;

public class AddProduct : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public AddProduct(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/user/cart/add-product", HttpMethodType.POST)]
  [OpenApiOperation("Cart")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result Handle(Guid id) {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = _cartService.AddOrIncreaseProduct(userId, id);
      _logService.UserLog(UserActionType.AddProductToCart, res, userId, id);
      return res;
    }

    HttpContext.AddOrIncreaseInCart(id);
    return DefResult.OkAdded(nameof(Cart));
  }
}