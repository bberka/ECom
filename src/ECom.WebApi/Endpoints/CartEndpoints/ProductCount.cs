using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(ProductCount))]
public class ProductCount : EndpointBaseSync.WithoutRequest.WithResult<int>
{
  private readonly ICartService _cartService;

  public ProductCount(ICartService cartService) {
    _cartService = cartService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ProductCount),"Gets cart product count")]
  public override int Handle() {
    if (!HttpContext.IsUserAuthenticated()) return HttpContext.GetCart().Count;
    var userId = HttpContext.GetUserId();
    return _cartService.GetBasketProductCount(userId);
  }
}