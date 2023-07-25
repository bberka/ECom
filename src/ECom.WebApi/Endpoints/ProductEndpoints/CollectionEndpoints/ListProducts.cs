using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.Base;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

public class ListProducts
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public ListProducts(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  //[HttpGet]
  //public ActionResult<CustomResult<ListProducts<CollectionProduct>>> GetProducts(int id, ushort page,
  //  string culture = ConstantMgr.DefaultCulture) {
  //  var userId = HttpContext.GetUserId();
  //  var res = _collectionService.GetCollectionProducts(userId, id, page, culture);
  //  _logService.UserLog(res.ToResult(), userId, "Collection.GetProducts", id, page, culture);
  //  return res.ToActionResult();
  //}
}