﻿using ECom.Foundation.Entities;
using ECom.Foundation.Models;

namespace ECom.Foundation.Extensions;

public static class CartExtensions
{
  public static void AddOrIncreaseInCart(this HttpContext context, Guid productId) {
    var currentCart = context.GetCart() ?? new List<SessionCart>();
    var current = currentCart.FirstOrDefault(x => x.ProductId == productId);
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

  public static void RemoveOrDecreaseInCart(this HttpContext context, Guid productId) {
    var currentCart = context.GetCart() ?? new List<SessionCart>();
    var current = currentCart.FirstOrDefault(x => x.ProductId == productId);
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

  public static IEnumerable<Cart> GetDbCartEntity(this HttpContext context, Guid? userId) {
    var current = context.GetCart();
    return current.Select(x => new Cart {
      Count = x.Count,
      UpdateDate = DateTime.Now,
      RegisterDate = DateTime.Now,
      ProductId = x.ProductId,
      UserId = userId ?? Guid.Empty
    });
  }
}