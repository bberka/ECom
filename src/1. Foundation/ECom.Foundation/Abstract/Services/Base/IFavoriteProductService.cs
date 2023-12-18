using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IFavoriteProductService
{
  List<FavoriteProduct> GetFavoriteProducts(Guid userId);
}