using ECom.Foundation.Static;

namespace ECom.Service.UserApi.Controllers;

[AllowAnonymous]
public class CartController : UserControllerBase
{
  [FromServices]
  public ICartService CartService { get; set; }

  [Endpoint("/user/cart/add-product", HttpMethodType.POST)]
  public Result AddProduct(Guid id) {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = CartService.AddOrIncreaseProduct(userId, id);
      LogService.UserLog(UserActionType.AddProductToCart, res, userId, id);
      return res;
    }

    HttpContext.AddOrIncreaseInCart(id);
    return DomResults.x_is_added_successfully("cart");
  }

  [Endpoint("/user/cart/clear", HttpMethodType.POST)]
  public Result Clear() {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = CartService.ClearCartProducts(userId);
      LogService.UserLog(UserActionType.ClearCart, res, userId);
      return res;
    }

    HttpContext.ClearCart();
    return DomResults.x_is_cleared_successfully("cart");
  }

  [Endpoint("/user/cart/list-products", HttpMethodType.GET)]
  public List<Cart> ListProducts() {
    if (!HttpContext.IsAuthenticated())
      return HttpContext.GetDbCartEntity(null).ToList();
    var userId = HttpContext.GetAuthId();
    var list = CartService.ListBasketProducts(userId);
    LogService.UserLog(UserActionType.ListCartProducts, list, userId);
    return list.Value;
  }

  [Endpoint("/user/cart/product-count", HttpMethodType.GET)]
  public int ProductCount() {
    if (!HttpContext.IsAuthenticated()) return HttpContext.GetCart().Count;
    var userId = HttpContext.GetAuthId();
    var count = CartService.GetBasketProductCount(userId);
    LogService.UserLog(UserActionType.GetCartProductCount, userId, count);
    return count;
  }

  [Endpoint("/user/cart/remove-product", HttpMethodType.POST)]
  public Result RemoveProduct(Guid id) {
    if (HttpContext.IsAuthenticated()) {
      var userId = HttpContext.GetAuthId();
      var res = CartService.RemoveOrDecreaseProduct(userId, id);
      LogService.UserLog(UserActionType.RemoveOrDecreaseProductFromCart, res, userId, id);
      return res;
    }

    HttpContext.RemoveOrDecreaseInCart(id);
    return DomResults.x_is_removed_successfully("cart");
  }
}