using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Base;

public interface ICartService
{
    CustomResult AddOrIncreaseProduct(Guid userId, Guid productId);
    int GetBasketProductCount(Guid userId);
    List<Cart> ListBasketProducts(Guid userId);
    CustomResult RemoveOrDecreaseProduct(Guid userId, Guid productId);
    CustomResult ClearCartProducts(Guid userId);
}