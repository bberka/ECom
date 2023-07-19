using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.AddressEndpoints;

[Authorize]
[EndpointRoute(typeof(Delete))]
public class Delete : EndpointBaseSync.WithRequest<int>.WithResult<CustomResult>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public Delete(ILogService logService, IAddressService addressService) {
    _logService = logService;
    _addressService = addressService;
  }

  [HttpDelete]
  [EndpointSwaggerOperation(typeof(Delete), "Deletes an address")]
  public override CustomResult Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.DeleteAddress(userId, id);
    _logService.UserLog(res, userId, "Address.Delete");
    return res;
  }
}