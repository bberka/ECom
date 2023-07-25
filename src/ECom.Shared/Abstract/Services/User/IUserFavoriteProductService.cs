using ECom.Shared.Abstract.Services.Base;

namespace ECom.Shared.Abstract.Services.User;

public interface IUserFavoriteProductService : IFavoriteProductService
{
  CustomResult AddFavoriteProduct(Guid userId, Guid productId);
  CustomResult RemoveFavoriteProduct(Guid userId, Guid productId);
}