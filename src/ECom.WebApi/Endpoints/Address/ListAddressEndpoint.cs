using ECom.Application.Services;
using ECom.Domain.Abstract;

namespace ECom.WebApi.Endpoints.Address;

[Authorize]
[EndpointRoute(typeof(UpdateAddressEndpoint))]
public class ListAddressEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Address>>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public ListAddressEndpoint(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }
  [HttpGet]
  [EndpointSwaggerOperation(typeof(ListAddressEndpoint),"Lists all addresses for the current user")]
  public override List<Domain.Entities.Address> Handle() {
    var user = HttpContext.GetUser();
    var res = _addressService.GetUserAddresses(user.Id);
    return res;
  }
}