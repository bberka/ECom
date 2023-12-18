namespace ECom.Service.UserApi.Controllers;

[AuthorizeUserOnly]
public class ProductFavoritesController : UserControllerBase
{
  [FromServices]

  public IUserFavoriteProductService UserFavoriteProductService { get; set; }

  [FromServices]

  public IFavoriteProductService FavoriteProductService { get; set; }


  [Endpoint("/user/product/favorite/add", HttpMethodType.POST)]
  public Result AddProduct(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = UserFavoriteProductService.AddFavoriteProduct(userId, id);
    LogService.UserLog(UserActionType.AddProductToFavorites, res, userId, id);
    return res;
  }

  [Endpoint("/user/product/favorite/list", HttpMethodType.GET)]
  public List<FavoriteProduct> Products() {
    var userId = HttpContext.GetUserId();
    var res = FavoriteProductService.GetFavoriteProducts(userId);
    LogService.UserLog(UserActionType.ListFavoriteProducts, userId);
    return res;
  }

  [Endpoint("/user/product/favorite/remove", HttpMethodType.DELETE)]
  public Result RemoveProduct(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = UserFavoriteProductService.RemoveFavoriteProduct(userId, id);
    LogService.UserLog(UserActionType.RemoveProductFromFavorites, res, userId, id);
    return res;
  }
}