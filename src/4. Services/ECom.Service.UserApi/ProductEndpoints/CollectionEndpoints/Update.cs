namespace ECom.Service.UserApi.ProductEndpoints.CollectionEndpoints;

public class Update : EndpointBaseSync.WithRequest<Request_Collection_Update>.WithResult<Result>
{
  private readonly IUserCollectionService _collectionService;
  private readonly ILogService _logService;

  public Update(IUserCollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/collection/update", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Product_Collection")]
  public override Result Handle(Request_Collection_Update request) {
    var authId = HttpContext.GetUserId();
    var res = _collectionService.UpdateCollection(authId, request);
    _logService.UserLog(UserActionType.UpdateCollection, res, authId, request.ToJsonString());
    return res;
  }
}