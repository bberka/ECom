namespace ECom.Service.AdminApi.AccountEndpoints;

public class GetInfo : EndpointBaseSync.WithoutRequest.WithResult<UserDto>
{
  [AuthorizeAdminOnly]
  [Endpoint("/admin/account/get", HttpMethodType.GET)]
  [EndpointSwaggerOperation("Admin_Account")]
  public override UserDto Handle() {
    var user = HttpContext.GetUser();
    return user;
  }
}