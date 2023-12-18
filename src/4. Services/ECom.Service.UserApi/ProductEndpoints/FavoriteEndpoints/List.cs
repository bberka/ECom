namespace ECom.Service.UserApi.ProductEndpoints.FavoriteEndpoints;

public class List : EndpointBaseSync.WithoutRequest.WithResult<List<FavoriteProduct>>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public List(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/favorite/list", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Product_Favorite")]
  public override List<FavoriteProduct> Handle() {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.GetFavoriteProducts(userId);
    _logService.UserLog(UserActionType.ListFavoriteProducts, userId);
    return res;
  }
}