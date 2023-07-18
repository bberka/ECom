using ECom.Application.Attributes;
using ECom.Domain.DTOs.CollectionDto;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(Create))]
public class Create : EndpointBaseSync.WithRequest<AddCollectionRequest>.WithResult<CustomResult>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Create(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Create),"Creates product collection")]
  public override CustomResult Handle(AddCollectionRequest request) {
    var res = _collectionService.CreateCollection(request);
    _logService.UserLog(res, request.AuthenticatedUserId, "Collection.Create", request.ToJsonString());
    return res;
  }
}