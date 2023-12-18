using ECom.Service.UserApi.Attributes;

namespace ECom.Service.UserApi.Controllers.ProductEndpoints.CollectionEndpoints;

public class Get : EndpointBaseSync.WithRequest<Guid>.WithResult<Result<Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Get(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/collection/get", HttpMethodType.GET)]
  [OpenApiOperation("Product_Collection")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result<Collection> Handle(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.GetCollection(userId, id);
    _logService.UserLog(UserActionType.GetCollection, res, userId, id);
    return res;
  }
}