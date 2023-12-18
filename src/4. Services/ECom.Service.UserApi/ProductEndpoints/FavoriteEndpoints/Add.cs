namespace ECom.Service.UserApi.ProductEndpoints.FavoriteEndpoints;

public class Add : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly IUserFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public Add(
    IUserFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/favorite/add", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Product_Favorite")]
  public override Result Handle(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.AddFavoriteProduct(userId, id);
    _logService.UserLog(UserActionType.AddProductToFavorites, res, userId, id);
    return res;
  }
}