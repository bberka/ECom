
using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public List(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(List),"Lists product collections")]
  public override List<Domain.Entities.Collection> Handle() {
    var userId = HttpContext.GetUserId();
    return _collectionService.GetCollections(userId);
  }
}