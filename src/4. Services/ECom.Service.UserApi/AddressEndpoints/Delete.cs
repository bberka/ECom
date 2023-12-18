namespace ECom.Service.UserApi.AddressEndpoints;

public class Delete : EndpointBaseSync.WithRequest<Guid>.WithResult<Result>
{
  private readonly IUserAddressService _addressService;
  private readonly ILogService _logService;

  public Delete(ILogService logService, IUserAddressService addressService) {
    _logService = logService;
    _addressService = addressService;
  }

  [AuthorizeUserOnly]
  [Endpoint("/user/address/delete", HttpMethodType.DELETE)]
  [EndpointSwaggerOperation("User_Address")]
  public override Result Handle(Guid id) {
    var userId = HttpContext.GetAuthId();
    var res = _addressService.DeleteAddress(userId, id);
    _logService.UserLog(UserActionType.DeleteAddress, res, userId);
    return res;
  }
}