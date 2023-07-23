using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IFavoriteProductService
{
  CustomResult AddFavoriteProduct(Guid userId, Guid productId);
  CustomResult RemoveFavoriteProduct(Guid userId, Guid productId);
  List<FavoriteProduct> GetFavoriteProducts(Guid userId);
}