using ECom.Application.Attributes;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateUserRequest>.WithResult<CustomResult>
{
  private readonly IUserService _userService;
  private readonly ILogService _logService;

  public Update(IUserService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(Update))]
  public override CustomResult Handle(UpdateUserRequest request) {
    var userId = request.AuthenticatedUserId;
    var res = _userService.Update(request);
    _logService.UserLog(res, userId, "Account.Update", request.ToJsonString());
    return res;
  }
}