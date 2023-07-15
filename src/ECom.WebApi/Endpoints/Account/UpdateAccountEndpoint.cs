using Ardalis.ApiEndpoints;
using ECom.Domain.DTOs.UserDTOs;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace ECom.WebApi.Endpoints.Account;

[Authorize]
[EndpointRoute(typeof(UpdateAccountEndpoint))]
public class UpdateAccountEndpoint : EndpointBaseSync.WithRequest<UpdateUserRequest>.WithResult<Result>
{
  private readonly IUserService _userService;
  private readonly ILogService _logService;

  public UpdateAccountEndpoint(IUserService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(UpdateAccountEndpoint))]
  public override Result Handle(UpdateUserRequest request) {
    var userId = request.AuthenticatedUserId;
    var res = _userService.Update(request);
    _logService.UserLog(res, userId, "Account.Update", request.ToJsonString());
    return res;
  }
}