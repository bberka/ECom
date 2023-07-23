using ECom.Application.Attributes;
using ECom.Domain.Entities;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(ListProducts))]
public class ListProducts : EndpointBaseSync.WithoutRequest.WithResult<List<Cart>>
{
  private readonly ICartService _cartService;

  public ListProducts(ICartService cartService) {
    _cartService = cartService;
  }

  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListProducts), "Gets cart products")]
  public override List<Cart> Handle() {
    if (!HttpContext.IsUserAuthenticated()) return HttpContext.GetDbCartEntity(null).ToList();
    var userId = HttpContext.GetUserId();
    return _cartService.ListBasketProducts(userId);
  }
}