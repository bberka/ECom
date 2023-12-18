using ECom.Foundation.Abstract.Services.Admin;
using ECom.Foundation.DTOs.Response;

namespace ECom.Service.Admin.AuthEndpoints;

public class Login : EndpointBaseSync.WithRequest<Request_Login>.WithResult<Result<Response_Admin_Login>>
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;
  private readonly ILogService _logService;

  public Login(IAdminJwtAuthenticator adminJwtAuthenticator, ILogService logService) {
    _adminJwtAuthenticator = adminJwtAuthenticator;
    _logService = logService;
  }

  [AllowAnonymous]
  [Endpoint("/admin/auth/login", HttpMethodType.POST)]
  [EndpointSwaggerOperation("Admin_Auth")]
  public override Result<Response_Admin_Login> Handle(Request_Login request) {
    var res = _adminJwtAuthenticator.Authenticate(request);
    var adminId = res.Data?.Admin.Id;
    _logService.AdminLog(AdminActionType.Login, res, adminId, request.EmailAddress);
    return res;
  }
}