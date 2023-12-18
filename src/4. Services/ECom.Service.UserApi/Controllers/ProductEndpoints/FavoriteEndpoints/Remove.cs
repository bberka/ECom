using ECom.Service.UserApi.Attributes;

namespace ECom.Service.UserApi.Controllers.ProductEndpoints.FavoriteEndpoints;

public class Remove : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly IUserFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public Remove(
    IUserFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/favorite/remove", HttpMethodType.DELETE)]
  [OpenApiOperation("Product_Favorite")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result Handle(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.RemoveFavoriteProduct(userId, id);
    _logService.UserLog(UserActionType.RemoveProductFromFavorites, res, userId, id);
    return res;
  }
}