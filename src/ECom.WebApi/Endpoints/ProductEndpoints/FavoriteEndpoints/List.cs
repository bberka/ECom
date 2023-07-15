using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.FavoriteEndpoints;

[Authorize]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithRequest<ushort>.WithResult<List<FavoriteProduct>>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public List(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(List),"Lists favorite products")]
  public override List<FavoriteProduct> Handle(ushort page) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.GetFavoriteProducts(userId, page);
    return res;
  }
}