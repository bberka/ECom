using ECom.Application.Attributes;
using ECom.Domain.Abstract.Services;
using ECom.Domain.Abstract.Services.User;
using ECom.Shared.DTOs;

namespace ECom.WebApi.Endpoints.AccountEndpoints;

[Authorize]
[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateUserRequest>.WithResult<CustomResult>
{
  private readonly ILogService _logService;
  private readonly IUserAccountService _userService;

  public Update(IUserAccountService userService, ILogService logService) {
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