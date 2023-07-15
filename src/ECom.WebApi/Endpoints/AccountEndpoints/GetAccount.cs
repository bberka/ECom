using ECom.Application.Attributes;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(GetAccount))]
public class GetAccount : EndpointBaseSync.WithoutRequest.WithResult<UserDto>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetAccount),"Gets authenticated user account information")]
  public override UserDto Handle() {
    var user = HttpContext.GetUser();
    return user;
  }
}