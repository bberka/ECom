namespace ECom.WebApi.Endpoints.Cart;

[AllowAnonymous]
[EndpointRoute(typeof(CartProductCountEndpoint))]
public class CartProductCountEndpoint : EndpointBaseSync.WithoutRequest.WithResult<int>
{
  private readonly ICartService _cartService;

  public CartProductCountEndpoint(ICartService cartService) {
    _cartService = cartService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(CartProductCountEndpoint),"Gets cart product count")]
  public override int Handle() {
    if (!HttpContext.IsUserAuthenticated()) return HttpContext.GetCart().Count;
    var userId = HttpContext.GetUserId();
    return _cartService.GetBasketProductCount(userId);
  }
}