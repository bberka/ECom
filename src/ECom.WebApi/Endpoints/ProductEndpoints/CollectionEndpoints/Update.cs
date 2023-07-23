using ECom.Application.Attributes;
using ECom.Shared.DTOs.CollectionDto;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateCollectionRequest>.WithResult<CustomResult>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Update(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Update), "Updates product collection")]
  public override CustomResult Handle(UpdateCollectionRequest request) {
    var authId = HttpContext.GetUserId();
    var res = _collectionService.UpdateCollection(authId, request);
    _logService.UserLog(res, authId, "Collection.Update", request.ToJsonString());
    return res;
  }
}