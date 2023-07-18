using ECom.Domain;

namespace ECom.Application.Services;

public class AddressService : IAddressService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserService _userService;

  public AddressService(
    IUnitOfWork unitOfWork,
    IUserService userService) {
    _unitOfWork = unitOfWork;
    _userService = userService;
  }


  public CustomResult DeleteAddress(int userId, int id) {
    var addressResult = GetAddress(userId, id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data;
    if (address is null) return DomainResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Address));
    address.DeleteDate = DateTime.Now;
    _unitOfWork.AddressRepository.Update(address);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAddress));
    return DomainResult.OkDeleted(nameof(Address));
  }

  public List<Address> GetUserAddresses(int userId) {
    return _unitOfWork.AddressRepository.Get(x => x.UserId == userId && !x.DeleteDate.HasValue).ToList();
  }

  public CustomResult UpdateAddress(int userId, Address data) {
    var addressResult = GetAddress(userId, data.Id);
    if (!addressResult.Status) return addressResult;
    var address = addressResult.Data!;
    if (address.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Address));
    _unitOfWork.AddressRepository.Update(data);
    if (!_unitOfWork.Save()) return DomainResult.DbInternalError(nameof(UpdateAddress));
    return DomainResult.OkUpdated(nameof(Address));
  }

  public CustomResult AddAddress(int userId, Address address) {
    _unitOfWork.AddressRepository.Insert(address);
    if (!_unitOfWork.Save()) return DomainResult.DbInternalError(nameof(AddAddress));
    return DomainResult.OkAdded(nameof(Address));
  }

  public CustomResult<Address> GetAddress(int addressId) {
    var address = _unitOfWork.AddressRepository.GetById(addressId);
    if (address is null) return DomainResult.NotFound(nameof(Address));
    if (address.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Address));
    return address;
  }

  public CustomResult<Address> GetAddress(int userId, int addressId) {
    var addressResult = GetAddress(addressId);
    if (!addressResult.Status) return addressResult;
    var isAuthorized = addressResult.Data?.UserId == userId;
    if (isAuthorized == false) return DomainResult.Unauthorized();
    return addressResult.Data;
  }
}