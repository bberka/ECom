using Swashbuckle.AspNetCore.Annotations;

namespace ECom.WebApi.Endpoints.Product.Favorite;

[Authorize]
[EndpointRoute(typeof(AddFavoriteProductEndpoint))]
public class AddFavoriteProductEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public AddFavoriteProductEndpoint(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(AddFavoriteProductEndpoint),"Adds product to favorite list")]
  public override Result Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.AddProduct(userId, id);
    _logService.UserLog(res, userId, "FavoriteProduct.Add", id);
    return res;
  }
}