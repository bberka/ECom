using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.WebApi.Endpoints.Product.Collection;

[Authorize]
[EndpointRoute(typeof(UpdateCollectionEndpoint))]
public class UpdateCollectionEndpoint : EndpointBaseSync.WithRequest<UpdateCollectionRequest>.WithResult<Result>
{

  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public UpdateCollectionEndpoint(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(UpdateCollectionEndpoint),"Updates product collection")]
  public override Result Handle(UpdateCollectionRequest request) {
    var res = _collectionService.UpdateCollection(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Collection.Update", request.ToJsonString());
    return res;
  }
}