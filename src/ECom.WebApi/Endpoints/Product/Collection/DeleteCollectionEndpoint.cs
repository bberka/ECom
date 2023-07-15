namespace ECom.WebApi.Endpoints.Product.Collection;

[Authorize]
[EndpointRoute(typeof(DeleteCollectionEndpoint))]
public class DeleteCollectionEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public DeleteCollectionEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [HttpDelete]
  [EndpointSwaggerOperation(typeof(DeleteCollectionEndpoint),"Deletes product collection")]
  public override Result Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.DeleteCollection(userId, id);
    _logService.UserLog(res, userId, "Collection.Delete", id);
    return res;
  }
}