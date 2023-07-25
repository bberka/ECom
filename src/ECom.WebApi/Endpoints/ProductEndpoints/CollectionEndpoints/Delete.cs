using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.Base;

namespace ECom.WebApi.Endpoints.ProductEndpoints.CollectionEndpoints;

[Authorize]
[EndpointRoute(typeof(Delete))]
public class Delete : EndpointBaseSync.WithRequest<Guid>.WithResult<CustomResult>
{
  private readonly ICollectionService _collectionService;
  private readonly ILogService _logService;

  public Delete(ICollectionService collectionService, ILogService logService) {
    _collectionService = collectionService;
    _logService = logService;
  }

  [HttpDelete]
  [EndpointSwaggerOperation(typeof(Delete), "Deletes product collection")]
  public override CustomResult Handle(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = _collectionService.DeleteCollection(userId, id);
    _logService.UserLog(res, userId, "Collection.Delete", id);
    return res;
  }
}