using ECom.Service.UserApi.Attributes;

namespace ECom.Service.UserApi.Controllers.ProductEndpoints.FavoriteEndpoints;

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
  [OpenApiOperation("Product_Favorite")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override List<FavoriteProduct> Handle() {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.GetFavoriteProducts(userId);
    _logService.UserLog(UserActionType.ListFavoriteProducts, userId);
    return res;
  }
}