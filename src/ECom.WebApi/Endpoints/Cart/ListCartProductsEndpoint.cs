namespace ECom.WebApi.Endpoints.Cart;

[AllowAnonymous]
[EndpointRoute(typeof(ListCartProductsEndpoint))]
public class ListCartProductsEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Cart>>
{
  private readonly ICartService _cartService;

  public ListCartProductsEndpoint(ICartService cartService) {
    _cartService = cartService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListCartProductsEndpoint),"Gets cart products")]
  public override List<Domain.Entities.Cart> Handle() {
    if (!HttpContext.IsUserAuthenticated()) return HttpContext.GetDbCartEntity(-1).ToList();
    var userId = HttpContext.GetUserId();
    return _cartService.ListBasketProducts(userId);

  }
}