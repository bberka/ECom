namespace ECom.Service.UserApi.AddressEndpoints;

public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Address>>
{
  [FromServices]
  public IAddressService AddressService { get; set; }

  [FromServices]
  public ILogService LogService { get; set; }

  [AuthorizeUserOnly]
  [Endpoint("/user/address/list", HttpMethodType.GET)]
  [EndpointSwaggerOperation("User_Address")]
  public override List<Address> Handle() {
    var userId = HttpContext.GetAuthId();
    var res = AddressService.GetUserAddresses(userId);
    LogService.UserLog(UserActionType.ListAddresses, res, userId);
    return res.Data;
  }
}