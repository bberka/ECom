using ECom.Application.Attributes;
using ECom.Domain.DTOs.CollectionDTOs;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateCollectionRequest>.WithResult<Result>
{

  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Update(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(Update),"Updates product collection")]
  public override Result Handle(UpdateCollectionRequest request) {
    var res = _collectionService.UpdateCollection(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Collection.Update", request.ToJsonString());
    return res;
  }
}