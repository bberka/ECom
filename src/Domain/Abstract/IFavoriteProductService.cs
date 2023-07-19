using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IFavoriteProductService
{
  CustomResult AddFavoriteProduct(int userId, int productId);
  CustomResult RemoveFavoriteProduct(int userId, int productId);
  List<FavoriteProduct> GetFavoriteProducts(int userId, ushort page, string culture = ConstantMgr.DefaultCulture);
}