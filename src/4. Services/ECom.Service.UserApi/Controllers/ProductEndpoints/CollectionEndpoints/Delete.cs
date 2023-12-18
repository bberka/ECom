using ECom.Service.UserApi.Attributes;

namespace ECom.Service.UserApi.Controllers.ProductEndpoints.CollectionEndpoints;

public class Delete : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly IUserCollectionService _collectionService;
  private readonly ILogService _logService;

  public Delete(IUserCollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/product/collection/delete", HttpMethodType.DELETE)]
  [OpenApiOperation("Product_Collection")]
  [OpenApiTag(UserServiceResolver.DocName)]
  public override Result Handle(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.DeleteCollection(userId, id);
    _logService.UserLog(UserActionType.DeleteCollection, res, userId, id);
    return res;
  }
}