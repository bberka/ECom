using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.FavoriteEndpoints;

[Authorize]
[EndpointRoute(typeof(Remove))]
public class Remove : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly IFavoriteProductService _favoriteProductService;
  private readonly ILogService _logService;

  public Remove(
    IFavoriteProductService favoriteProductService,
    ILogService logService) {
    _favoriteProductService = favoriteProductService;
    _logService = logService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(Remove),"Removes product from favorite list")]
  public override CustomResult Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _favoriteProductService.RemoveProduct(userId, id);
    _logService.UserLog(res, userId, "FavoriteProduct.Remove", id);
    return res;
  }
}