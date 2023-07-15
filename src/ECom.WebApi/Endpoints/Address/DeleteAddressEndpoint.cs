

namespace ECom.WebApi.Endpoints.Address;

[Authorize]
[EndpointRoute(typeof(DeleteAddressEndpoint))]
public class DeleteAddressEndpoint : EndpointBaseSync.WithRequest<int>.WithResult<Result>
{
  private readonly ILogService _logService;
  private readonly IAddressService _addressService;

  public DeleteAddressEndpoint(ILogService logService, IAddressService addressService) {
    _logService = logService;
    _addressService = addressService;
  }
  [HttpDelete]
  [EndpointSwaggerOperation(typeof(DeleteAddressEndpoint),"Deletes an address")]
  public override Result Handle(int id) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.DeleteAddress(userId, id);
    _logService.UserLog(res, userId, "Address.Delete");
    return res;
  }
}