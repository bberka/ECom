using Ardalis.ApiEndpoints;
using ECom.Domain.DTOs.UserDTOs;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Endpoints.Account;

[Authorize]
[EndpointRoute(typeof(GetAccountEndpoint))]
public class GetAccountEndpoint : EndpointBaseSync.WithoutRequest.WithResult<UserDto>
{
  [HttpGet]
  [EndpointSwaggerOperation(typeof(GetAccountEndpoint),"Gets authenticated user account information")]
  public override UserDto Handle() {
    var user = HttpContext.GetUser();
    return user;
  }
}