namespace ECom.AdminApi.Endpoints.AuthEndpoints;

[EndpointRoute(typeof(Login))]
public class Login : EndpointBaseSync.WithRequest<LoginRequest>.WithResult<CustomResult<AdminLoginResponse>>
{
  private readonly IAdminJwtAuthenticator _adminJwtAuthenticator;
  private readonly ILogService _logService;

  public Login(IAdminJwtAuthenticator adminJwtAuthenticator,ILogService logService"")
  {
    _adminJwtAuthenticator = adminJwtAuthenticator;
    _logService = logService;
  }
  [HttpPost]
  [EndpointSwaggerOperation(typeof(Login),"Logins admin")]
  public override CustomResult<AdminLoginResponse> Handle(LoginRequest request)
  {
    var res = _adminJwtAuthenticator.Authenticate(request);
    var adminId = res.Data?.Admin.Id;
    _logService.AdminLog(res.ToResult(), adminId, "Auth.Login", request.EmailAddress, request.EncryptedPassword);
    return res;
  }
}