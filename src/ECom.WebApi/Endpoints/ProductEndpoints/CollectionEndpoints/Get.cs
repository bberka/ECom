using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(Get))]
public class Get : EndpointBaseSync.WithRequest<int>.WithResult<ResultData<Domain.Entities.Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Get(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(Get),"Gets product collection")]
  public override ResultData<Domain.Entities.Collection> Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.GetCollection(userId, id);
    _logService.UserLog(res.ToResult(), userId, "Collection.Get", id);
    return res;
  }
}