namespace ECom.Foundation.Abstract.Services.User;

public interface IUserFavoriteProductService
{
  Result AddFavoriteProduct(Guid userId, Guid productId);
  Result RemoveFavoriteProduct(Guid userId, Guid productId);
}