namespace ECom.Service.UserApi.AddressEndpoints;

public class Add : EndpointBaseSync.WithRequest<Request_Address_Add>.WithResult<Result>
{
  private readonly IUserAddressService _addressService;
  private readonly ILogService _logService;

  public Add(IUserAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }


  [AuthorizeUserOnly]
  [Endpoint("/user/address/add", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Address")]
  public override Result Handle(Request_Address_Add requestAddress) {
    var userId = HttpContext.GetAuthId();
    var res = _addressService.AddAddress(userId, requestAddress);
    _logService.UserLog(UserActionType.AddAddress, res, userId, requestAddress.ToJsonString());
    return res;
  }
}