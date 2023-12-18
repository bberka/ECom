using ECom.Foundation.Abstract.Services.Admin;

namespace ECom.Service.Admin.AccountEndpoints;

public class ChangePassword : EndpointBaseSync.WithRequest<Request_Password_Change>.WithResult<Result>
{
  private readonly IAdminAccountService _adminAccountService;
  private readonly ILogService _logService;

  public ChangePassword(ILogService logService, IAdminAccountService adminAccountService) {
    _logService = logService;
    _adminAccountService = adminAccountService;
  }

  [AuthorizeAdminOnly]
  [Endpoint("/admin/account/change-password", HttpMethodType.POST)]
  [EndpointSwaggerOperation("Admin_Account")]
  public override Result Handle(Request_Password_Change requestPassword) {
    var authId = HttpContext.GetAuthId();
    var res = _adminAccountService.ChangePassword(authId, requestPassword);
    _logService.AdminLog(AdminActionType.ChangePassword, res, authId);
    return res;
  }
}