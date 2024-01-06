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
    if (!addressResult.Status) return addressResult.ToResult();
    var address = addressResult.Value;
    address.DeleteDate = DateTime.Now;
    _unitOfWork.Addresses.Update(address);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateAddress));
    return DomResults.x_is_deleted_successfully("address");
  }

  public Result UpdateAddress(Guid userId, Address data) {
    var addressResult = GetAddress(userId, data.Id);
    if (!addressResult.Status) return addressResult.ToResult();
    var address = addressResult.Value!;
    _unitOfWork.Addresses.Update(data);
    if (!_unitOfWork.Save()) return DomResults.db_internal_error(nameof(UpdateAddress));
    return DomResults.x_is_updated_successfully("address");
  }

  public Result AddAddress(Guid userId, Request_Address_Add requestAddress) {
    var address = AddressMapper.FromRequestAddAddress(requestAddress);
    _unitOfWork.Addresses.Add(address);
    if (!_unitOfWork.Save()) return DomResults.db_internal_error(nameof(AddAddress));
    return DomResults.x_is_added_successfully("address");
  }

  public Result<Address> GetAddress(Guid userId, Guid addressId) {
    var addressResult = GetAddress(addressId);
    if (!addressResult.Status) return addressResult;
    var isAuthorized = addressResult.Value?.UserId == userId;
    if (isAuthorized == false) return DomResults.unauthorized();
    return addressResult.Value;
  }

  public Result<Address> GetAddress(Guid addressId) {
    var address = _unitOfWork.Addresses.Find(addressId);
    if (address is null || address.DeleteDate.HasValue) return DomResults.x_is_not_found("address");
    return address;
  }
}