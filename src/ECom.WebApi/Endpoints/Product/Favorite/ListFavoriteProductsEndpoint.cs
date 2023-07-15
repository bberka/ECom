using System.Text.RegularExpressions;

namespace ECom.WebApi.Endpoints.Product.Favorite;

[Authorize]
[EndpointRoute(typeof(ListFavoriteProductsEndpoint))]
public class ListFavoriteProductsEndpoint : EndpointBaseSync.WithRequest<ushort>.WithResult<List<FavoriteProduct>>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public ListFavoriteProductsEndpoint(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListFavoriteProductsEndpoint),"Lists favorite products")]
  public override List<FavoriteProduct> Handle(ushort page) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.GetFavoriteProducts(userId, page);
    return res;
  }
}