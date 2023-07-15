using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.AddressEndpoints;

[Authorize]
[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<Domain.Entities.Address>.WithResult<Result>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public Add(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(Add),"Adds a new address")]
  public override Result Handle(Domain.Entities.Address request) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.AddAddress(userId, request);
    _logService.UserLog(res, userId, "Address.Add", request.ToJsonString());
    return res;
  }
}