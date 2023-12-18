namespace ECom.Service.UserApi.AccountEndpoints;

public class GetInfo : EndpointBaseSync.WithoutRequest.WithResult<UserDto>
{
  [AuthorizeUserOnly]
  [Endpoint("/user/account/get", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Account")]
  public override UserDto Handle() {
    var user = HttpContext.GetUser();
    return user;
  }
}