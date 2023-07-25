using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Base;

public interface IFavoriteProductService
{
    List<FavoriteProduct> GetFavoriteProducts(Guid userId);
}