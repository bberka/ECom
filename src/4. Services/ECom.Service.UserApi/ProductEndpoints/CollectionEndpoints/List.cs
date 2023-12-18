namespace ECom.Service.UserApi.ProductEndpoints.CollectionEndpoints;

public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public List(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/collection/list", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Product_Collection")]
  public override List<Collection> Handle() {
    var userId = HttpContext.GetUserId();
    var list = _collectionService.GetCollections(userId);
    _logService.UserLog(UserActionType.ListCollections, userId);
    return list;
  }
}