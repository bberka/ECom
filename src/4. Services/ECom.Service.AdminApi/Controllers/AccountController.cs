using Swashbuckle.AspNetCore.Annotations;

namespace ECom.Service.AdminApi.Controllers;

[AuthorizeAdminOnly]
public class AccountController : AdminControllerBase
{
  [FromServices]
  public IAdminAccountService AdminAccountService { get; set; }


  [Endpoint("/admin/account/get-cache", HttpMethodType.GET)]
  [SwaggerOperation("Gets admin account information from jwt token")]
  public AdminDto GetCache() {
    return HttpContext.GetAdmin();
  }

  [Endpoint("/admin/account/get", HttpMethodType.GET)]
  public AdminDto Get() {
    var authId = HttpContext.GetAdminId();
    var res = AdminAccountService.GetAccountInformation(authId);
    LogService.AdminLog(AdminActionType.GetAccountInformation, authId);
    return res;
  }

  [Endpoint("/admin/account/update", HttpMethodType.POST)]
  public Result Update(Request_Admin_UpdateAccount request) {
    var authId = HttpContext.GetAdminId();
    var res = AdminAccountService.UpdateMyAccount(request);
    LogService.AdminLog(AdminActionType.UpdateMyAccount, res, authId, request);
    return res;
  }
}