namespace ECom.WebApi.Endpoints.Product.Collection;

public class ListProductsEndpoint  
{

  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public ListProductsEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  //[HttpGet]
  //public ActionResult<ResultData<List<CollectionProduct>>> GetProducts(int id, ushort page,
  //  string culture = ConstantMgr.DefaultCulture) {
  //  var userId = HttpContext.GetUserId();
  //  var res = _collectionService.GetCollectionProducts(userId, id, page, culture);
  //  _logService.UserLog(res.ToResult(), userId, "Collection.GetProducts", id, page, culture);
  //  return res.ToActionResult();
  //}

}