namespace ECom.Service.UserApi.ProductEndpoints.CollectionEndpoints;

public class Create : EndpointBaseSync.WithRequest<Request_Collection_Add>.WithResult<Result>
{
  private readonly IUserCollectionService _collectionService;
  private readonly ILogService _logService;

  public Create(IUserCollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/collection/create", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Product_Collection")]
  public override Result Handle(Request_Collection_Add request) {
    var authId = HttpContext.GetAuthId();
    var res = _collectionService.CreateCollection(authId, request);
    _logService.UserLog(UserActionType.CreateProductCollection, res, authId, request.ToJsonString());
    return res;
  }
}