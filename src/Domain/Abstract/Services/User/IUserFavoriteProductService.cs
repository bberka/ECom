using ECom.Domain.Abstract.Services.Base;

namespace ECom.Domain.Abstract.Services.User;

public interface IUserFavoriteProductService : IFavoriteProductService
{
  CustomResult AddFavoriteProduct(Guid userId, Guid productId);
  CustomResult RemoveFavoriteProduct(Guid userId, Guid productId);
}