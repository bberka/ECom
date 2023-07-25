using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.WebApi.Endpoints.AddressEndpoints;

[Authorize]
[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<Address>.WithResult<CustomResult>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public Add(IUserAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Add), "Adds a new address")]
  public override CustomResult Handle(Address request) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.AddAddress(userId, request);
    _logService.UserLog(res, userId, "Address.Add", request.ToJsonString());
    return res;
  }
}