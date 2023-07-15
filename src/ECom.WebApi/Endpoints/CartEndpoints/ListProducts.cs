using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(ListProducts))]
public class ListProducts : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Cart>>
{
  private readonly ICartService _cartService;

  public ListProducts(ICartService cartService) {
    _cartService = cartService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListProducts),"Gets cart products")]
  public override List<Domain.Entities.Cart> Handle() {
    if (!HttpContext.IsUserAuthenticated()) return HttpContext.GetDbCartEntity(-1).ToList();
    var userId = HttpContext.GetUserId();
    return _cartService.ListBasketProducts(userId);

  }
}