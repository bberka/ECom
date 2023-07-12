namespace ECom.Domain.Abstract;

public interface ICartService
{
  Result AddOrIncreaseProduct(int userId, int productId);
  int GetBasketProductCount(int userId);
  List<Cart> ListBasketProducts(int userId);
  Result RemoveOrDecreaseProduct(int userId, int productId);
  Result Clear(int userId);
}