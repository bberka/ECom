namespace ECom.Domain.Abstract;

public interface ICartService
{
  CustomResult AddOrIncreaseProduct(int userId, int productId);
  int GetBasketProductCount(int userId);
  List<Cart> ListBasketProducts(int userId);
  CustomResult RemoveOrDecreaseProduct(int userId, int productId);
  CustomResult ClearCartProducts(int userId);
}