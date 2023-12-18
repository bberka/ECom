namespace ECom.Service.UserApi.AddressEndpoints;

public class Update : EndpointBaseSync.WithRequest<Address>.WithResult<Result>
{
  private readonly IUserAddressService _addressService;
  private readonly ILogService _logService;

  public Update(IUserAddressService addressService, ILogService logService) {
    _addressService = addressService;
    _logService = logService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/address/update", HttpMethodType.POST)]
  [EndpointSwaggerOperation("User_Address")]
  public override Result Handle(Address address) {
    var userId = HttpContext.GetAuthId();
    var res = _addressService.UpdateAddress(userId, address);
    _logService.UserLog(UserActionType.UpdateAddress, res, userId, address.ToJsonString());
    return res;
  }
}