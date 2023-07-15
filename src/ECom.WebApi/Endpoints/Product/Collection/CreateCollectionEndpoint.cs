using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.WebApi.Endpoints.Product.Collection;

[Authorize]
[EndpointRoute(typeof(CreateCollectionEndpoint))]
public class CreateCollectionEndpoint : EndpointBaseSync.WithRequest<AddCollectionRequest>.WithResult<Result>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public CreateCollectionEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(CreateCollectionEndpoint),"Creates product collection")]
  public override Result Handle(AddCollectionRequest request) {
    var res = _collectionService.CreateCollection(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Collection.Create", request.ToJsonString());
    return res;
  }
}