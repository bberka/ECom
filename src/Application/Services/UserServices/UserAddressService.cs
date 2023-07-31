using ECom.Application.Services.BaseServices;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.User;
using ECom.Shared.Entities;

namespace ECom.Application.Services.UserServices;

public class UserAddressService : AddressService,IUserAddressService
{
  public UserAddressService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }

  public CustomResult DeleteAddress(Guid userId, Guid id) {
    var addressResult = GetAddress(userId, id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data;
    if (address is null) return DomainResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Address));
    address.DeleteDate = DateTime.Now;
    UnitOfWork.AddressRepository.Update(address);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAddress));
    return DomainResult.OkDeleted(nameof(Address));
  }
  public CustomResult UpdateAddress(Guid userId, Address data) {
    var addressResult = GetAddress(userId, data.Id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data!;
    if (address.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Address));
    UnitOfWork.AddressRepository.Update(data);
    if (!UnitOfWork.Save()) return DomainResult.DbInternalError(nameof(UpdateAddress));
    return DomainResult.OkUpdated(nameof(Address));
  }

  public CustomResult AddAddress(Guid userId, Address address) {
    UnitOfWork.AddressRepository.Add(address);
    if (!UnitOfWork.Save()) return DomainResult.DbInternalError(nameof(AddAddress));
    return DomainResult.OkAdded(nameof(Address));
  }

  public CustomResult<Address> GetAddress(Guid addressId) {
    var address = UnitOfWork.AddressRepository.Find(addressId);
    if (address is null) return DomainResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Address));
    return address;
  }

  public CustomResult<Address> GetAddress(Guid userId, Guid addressId) {
    var addressResult = GetAddress(addressId);
    if (!addressResult.Status) return addressResult;
    var isAuthorized = addressResult.Data?.UserId == userId;
    if (isAuthorized == false) return DomainResult.Unauthorized();
    return addressResult.Data;
  }
}