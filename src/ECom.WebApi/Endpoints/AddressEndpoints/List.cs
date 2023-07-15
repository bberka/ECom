using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.AddressEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Address>>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public List(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(List),"Lists all addresses for the current user")]
  public override List<Domain.Entities.Address> Handle() {
    var user = HttpContext.GetUser();
    var res = _addressService.GetUserAddresses(user.Id);
    return res;
  }
}