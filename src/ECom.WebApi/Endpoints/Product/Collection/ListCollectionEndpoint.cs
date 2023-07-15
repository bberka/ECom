
namespace ECom.WebApi.Endpoints.Product.Collection;

[Authorize]
[EndpointRoute(typeof(ListCollectionEndpoint))]
public class ListCollectionEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Collection>>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public ListCollectionEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListCollectionEndpoint),"Lists product collections")]
  public override List<Domain.Entities.Collection> Handle() {
    var userId = HttpContext.GetUserId();
    return _collectionService.GetCollections(userId);
  }
}