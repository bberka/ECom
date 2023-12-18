namespace ECom.Service.AdminApi.Controllers;

public class PasswordController : AdminControllerBase
{
  [FromServices]
  public IAdminAccountService AdminAccountService { get; set; }


  [AuthorizeAdminOnly]
  [Endpoint("/admin/password/change", HttpMethodType.POST)]
  public Result Change(Request_Password_Change requestPassword) {
    var authId = HttpContext.GetAdminId();
    var res = AdminAccountService.ChangePassword(authId, requestPassword);
    LogService.AdminLog(AdminActionType.ChangePassword, res, authId);
    return res;
  }
}