using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ICartService
{
  Result AddOrIncreaseProduct(Guid userId, Guid productId);
  int GetBasketProductCount(Guid userId);
  Result<List<Cart>> ListBasketProducts(Guid userId);
  Result RemoveOrDecreaseProduct(Guid userId, Guid productId);
  Result ClearCartProducts(Guid userId);
}