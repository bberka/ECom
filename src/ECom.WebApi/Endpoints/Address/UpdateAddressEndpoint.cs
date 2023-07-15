using ECom.Application.Services;

namespace ECom.WebApi.Endpoints.Address;

[Authorize]
[EndpointRoute(typeof(UpdateAddressEndpoint))]
public class UpdateAddressEndpoint : EndpointBaseSync.WithRequest<Domain.Entities.Address>.WithResult<Result>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public UpdateAddressEndpoint(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(UpdateAddressEndpoint), "Adds a new address")]
  public override Result Handle(Domain.Entities.Address address) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.UpdateAddress(userId, address);
    _logService.UserLog(res, userId, "Address.Update", address.ToJsonString());
    return res;
  }
}