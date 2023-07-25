using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Entities;

namespace ECom.WebApi.Endpoints.AddressEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<Address>.WithResult<CustomResult>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public Update(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Update), "Adds a new address")]
  public override CustomResult Handle(Address address) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.UpdateAddress(userId, address);
    _logService.UserLog(res, userId, "Address.Update", address.ToJsonString());
    return res;
  }
}