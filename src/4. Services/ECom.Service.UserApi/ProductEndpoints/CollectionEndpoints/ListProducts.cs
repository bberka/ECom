namespace ECom.Service.UserApi.ProductEndpoints.CollectionEndpoints;

// [Authorize]
// [Endpoint(typeof(ListProducts))]
// public class ListProducts : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult<ListProducts<CollectionProduct>>>
// {
//   private readonly ICollectionService _collectionService;
//   private readonly ILogService _logService;
//
//   public ListProducts(ICollectionService collectionService, ILogService logService) {
//     _collectionService = collectionService;
//     _logService = logService;
//   }
//   [HttpGet]
//   [EndpointSwaggerOperation(typeof(ListProducts), "Lists product collections")]
//   public CustomResult<ListProducts<CollectionProduct>> GetProducts(int id, ushort page,string culture = ConstantMgr.DefaultLanguage) {
//     throw new NotImplementedException();
//      var userId = HttpContext.GetUserId();
//      var res = _collectionService.GetCollectionProducts(userId, id, page, culture);
//      _logService.UserLog(res.ToResult(), userId, "Collection.GetProducts", id, page, culture);
//      return res.ToActionResult();
//   }
// }