using ECom.Business.Attributes;
using ECom.Foundation.Abstract.Services.Admin;
using ECom.Service.AdminApi.Abstract;
using ECom.Service.AdminApi.Attributes;

namespace ECom.Service.AdminApi.Controllers;

[AuthorizeAdminOnly]
public class AccountController : AdminControllerBase
{
  [FromServices]
  public IAdminAccountService AdminAccountService { get; set; }

  [Endpoint("/admin/account/get", HttpMethodType.GET)]
  public UserDto Get() {
    var user = HttpContext.GetUser();
    return user;
  }
}