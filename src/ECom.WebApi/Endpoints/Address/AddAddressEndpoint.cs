using Ardalis.ApiEndpoints;
using ECom.Application.Services;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Endpoints.Address;

[Authorize]
[EndpointRoute(typeof(AddAddressEndpoint))]
public class AddAddressEndpoint : EndpointBaseSync.WithRequest<Domain.Entities.Address>.WithResult<Result>
{
  private readonly IAddressService _addressService;
  private readonly ILogService _logService;

  public AddAddressEndpoint(IAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(AddAddressEndpoint),"Adds a new address")]
  public override Result Handle(Domain.Entities.Address request) {
    var userId = HttpContext.GetUserId();
    var res = _addressService.AddAddress(userId, request);
    _logService.UserLog(res, userId, "Address.Add", request.ToJsonString());
    return res;
  }
}