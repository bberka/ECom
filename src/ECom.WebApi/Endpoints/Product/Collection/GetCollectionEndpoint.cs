namespace ECom.WebApi.Endpoints.Product.Collection;

[Authorize]
[EndpointRoute(typeof(GetCollectionEndpoint))]
public class GetCollectionEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<ResultData<Domain.Entities.Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public GetCollectionEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetCollectionEndpoint),"Gets product collection")]
  public override ResultData<Domain.Entities.Collection> Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.GetCollection(userId, id);
    _logService.UserLog(res.ToResult(), userId, "Collection.Get", id);
    return res;
  }
}