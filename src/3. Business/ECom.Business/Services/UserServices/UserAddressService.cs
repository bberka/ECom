namespace ECom.Business.Services.UserServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class UserAddressService : IUserAddressService
{
  private readonly IUnitOfWork _unitOfWork;

  public UserAddressService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result DeleteAddress(Guid userId, Guid id) {
    var addressResult = GetAddress(userId, id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data;
    if (address is null) return DefResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DefResult.AlreadyDeleted(nameof(Address));
    address.DeleteDate = DateTime.Now;
    _unitOfWork.Addresses.Update(address);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateAddress));
    return DefResult.OkDeleted(nameof(Address));
  }

  public Result UpdateAddress(Guid userId, Address data) {
    var addressResult = GetAddress(userId, data.Id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data!;
    if (address.DeleteDate.HasValue) return DefResult.Deleted(nameof(Address));
    _unitOfWork.Addresses.Update(data);
    if (!_unitOfWork.Save()) return DefResult.DbInternalError(nameof(UpdateAddress));
    return DefResult.OkUpdated(nameof(Address));
  }

  public Result AddAddress(Guid userId, Request_Address_Add requestAddress) {
    var address = AddressMapper.FromRequestAddAddress(requestAddress);
    _unitOfWork.Addresses.Add(address);
    if (!_unitOfWork.Save()) return DefResult.DbInternalError(nameof(AddAddress));
    return DefResult.OkAdded(nameof(Address));
  }

  public Result<Address> GetAddress(Guid userId, Guid addressId) {
    var addressResult = GetAddress(addressId);
    if (!addressResult.Status) return addressResult;
    var isAuthorized = addressResult.Data?.UserId == userId;
    if (isAuthorized == false) return DefResult.Unauthorized();
    return addressResult.Data;
  }

  public Result<Address> GetAddress(Guid addressId) {
    var address = _unitOfWork.Addresses.Find(addressId);
    if (address is null) return DefResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DefResult.Deleted(nameof(Address));
    return address;
  }
}