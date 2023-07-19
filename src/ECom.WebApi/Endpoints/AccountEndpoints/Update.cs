using ECom.Application.Attributes;
using ECom.Shared.DTOs.UserDto;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateUserRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IUserService _userService;

  public Update(IUserService userService, ILogService logService) {
    _userService = userService;
    _logService = logService;
  }

  [HttpPost]
  [EndpointSwaggerOperation(typeof(Update))]
  public override CustomResult Handle(UpdateUserRequest request) {
    var authId = HttpContext.GetUserId();
    var res = _userService.UpdateUser(authId, request);
    _logService.UserLog(res, authId, "Account.Update", request.ToJsonString());
    return res;
  }
}