using ECom.Service.UserApi.Abstract;

namespace ECom.Service.UserApi.Controllers;

public class AddressController : UserControllerBase
{
  [FromServices]
  public IUserAddressService UserAddressService { get; set; }

  [FromServices]
  public IAddressService AddressService { get; set; }

  [Endpoint("/user/address/add", HttpMethodType.POST)]
  public Result Add(Request_Address_Add requestAddress) {
    var userId = HttpContext.GetAuthId();
    var res = UserAddressService.AddAddress(userId, requestAddress);
    LogService.UserLog(UserActionType.AddAddress, res, userId, requestAddress.ToJsonString());
    return res;
  }

  [Endpoint("/user/address/delete", HttpMethodType.DELETE)]
  public Result Delete(Guid id) {
    var userId = HttpContext.GetAuthId();
    var res = UserAddressService.DeleteAddress(userId, id);
    LogService.UserLog(UserActionType.DeleteAddress, res, userId);
    return res;
  }

  [Endpoint("/user/address/list", HttpMethodType.GET)]
  public List<Address> List() {
    var userId = HttpContext.GetAuthId();
    var res = AddressService.GetUserAddresses(userId);
    LogService.UserLog(UserActionType.ListAddresses, res, userId);
    return res.Data;
  }

  [Endpoint("/user/address/update", HttpMethodType.POST)]
  public Result Update(Address address) {
    var userId = HttpContext.GetAuthId();
    var res = UserAddressService.UpdateAddress(userId, address);
    LogService.UserLog(UserActionType.UpdateAddress, res, userId, address.ToJsonString());
    return res;
  }
}