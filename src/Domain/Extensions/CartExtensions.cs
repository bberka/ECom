using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Extensions;

public static class CartExtensions
{
  public static void AddOrIncreaseInCart(this HttpContext context, int productId) {
    var currentCart = context.GetCart() ?? new List<SessionCart>();
    var current = currentCart.Where(x => x.ProductId == productId).FirstOrDefault();
    if (current is not null)
      current.Count++;
    else
      currentCart.Add(new SessionCart {
        Count = 1,
        ProductId = productId
      });
    context.SaveCart(currentCart);
  }

  public static void SaveCart(this HttpContext context, List<SessionCart> cart) {
    context.Session.SetString("cart", cart.ToJsonString());
  }

  public static List<SessionCart> GetCart(this HttpContext context) {
    var res = context.Session.GetString("cart")?.FromJsonString<List<SessionCart>>();
    if (res == null) return new List<SessionCart>();
    return res;
  }

  public static void RemoveOrDecreaseInCart(this HttpContext context, int productId) {
    var currentCart = context.GetCart() ?? new List<SessionCart>();
    var current = currentCart.Where(x => x.ProductId == productId).FirstOrDefault();
    if (current is not null) {
      current.Count--;
      if (current.Count < 1)
        currentCart.Remove(current);
      context.SaveCart(currentCart);
    }
  }

  public static void ClearCart(this HttpContext context) {
    context.Session.Remove("cart");
  }

  public static List<Cart> GetDbCartEntity(this HttpContext context, int userId) {
    var current = context.GetCart();
    return current.Select(x => new Cart {
      Count = x.Count,
      LastUpdateDate = DateTime.Now,
      RegisterDate = DateTime.Now,
      ProductId = x.ProductId,
      UserId = userId
    }).ToList();
  }

  public static List<Cart> GetDbCartEntity(this HttpContext context) {
    var userId = context.GetUser().Id;
    var current = context.GetCart();
    return current.Select(x => new Cart {
      Count = x.Count,
      LastUpdateDate = DateTime.Now,
      RegisterDate = DateTime.Now,
      ProductId = x.ProductId,
      UserId = userId
    }).ToList();
  }
}