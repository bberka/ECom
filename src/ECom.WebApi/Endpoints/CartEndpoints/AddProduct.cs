using ECom.Application.Attributes;
using ECom.Domain.Entities;

namespace ECom.WebApi.Endpoints.CartEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(AddProduct))]
public class AddProduct : EndpointBaseSync.WithRequest<Guid>.WithResult<CustomResult>
{
  private readonly ICartService _cartService;
  private readonly ILogService _logService;

  public AddProduct(ICartService cartService, ILogService logService) {
    _cartService = cartService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(AddProduct), "Adds product to cart")]
  public override CustomResult Handle(Guid id) {
    if (HttpContext.IsUserAuthenticated()) {
      var userId = HttpContext.GetUserId();
      var res = _cartService.AddOrIncreaseProduct(userId, id);
      _logService.UserLog(res, userId, "Cart.AddOrIncreaseProduct", id);
      return res;
    }

    HttpContext.AddOrIncreaseInCart(id);
    return DomainResult.OkAdded(nameof(Cart));
  }
}