using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.FavoriteEndpoints;

[Authorize]
[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public Add(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Add), "Adds product to favorite list")]
  public override CustomResult Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.AddFavoriteProduct(userId, id);
    _logService.UserLog(res, userId, "FavoriteProduct.Add", id);
    return res;
  }
}