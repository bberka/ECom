namespace ECom.WebApi.Endpoints.Product.Favorite;

[Authorize]
[EndpointRoute(typeof(RemoveFavoriteProductEndpoint))]
public class RemoveFavoriteProductEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public RemoveFavoriteProductEndpoint(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(RemoveFavoriteProductEndpoint),"Removes product from favorite list")]
  public override Result Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.RemoveProduct(userId, id);
    _logService.UserLog(res, userId, "FavoriteProduct.Remove", id);
    return res;
  }
}