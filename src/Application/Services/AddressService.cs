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


  public Result DeleteAddress(int userId, int id) {
    var addressResult = GetAddress(userId, id);
    if (addressResult.IsFailure) return addressResult.ToResult();
    var address = addressResult.Data;
    if (address is null) return DomainResult.Address.NotFoundResult();
    if (address.DeleteDate.HasValue) return DomainResult.Address.AlreadyDeletedResult();
    address.DeleteDate = DateTime.Now;
    _unitOfWork.AddressRepository.Update(address);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Address.DeleteSuccessResult();
  }

  public List<Address> GetUserAddresses(int userId) {
    return _unitOfWork.AddressRepository.Get(x => x.UserId == userId && !x.DeleteDate.HasValue).ToList();
  }

  public Result UpdateAddress(int userId, Address data) {
    var addressResult = GetAddress(userId, data.Id);
    if (addressResult.IsFailure) return addressResult.ToResult();
    var address = addressResult.Data;
    if (address.DeleteDate.HasValue) return DomainResult.Address.DeletedResult();
    _unitOfWork.AddressRepository.Update(data);
    if (!_unitOfWork.Save()) return DomainResult.DbInternalErrorResult();
    return DomainResult.Address.UpdateSuccessResult();
  }

  public Result AddAddress(int userId, Address address) {
    _unitOfWork.AddressRepository.Insert(address);
    if (!_unitOfWork.Save()) return DomainResult.DbInternalErrorResult();
    return DomainResult.Address.AddSuccessResult();
  }

  public ResultData<Address> GetAddress(int addressId) {
    var address = _unitOfWork.AddressRepository.GetById(addressId);
    if (address is null) return DomainResult.Address.NotFoundResult();
    if (address.DeleteDate.HasValue) return DomainResult.Address.DeletedResult();
    return address;
  }

  public ResultData<Address> GetAddress(int userId, int addressId) {
    var addressResult = GetAddress(addressId);
    if (addressResult.IsFailure) return addressResult.ToResult();
    var isAuthorized = addressResult.Data?.UserId == userId;
    if (isAuthorized == false) return DomainResult.User.NotAuthorizedResult();
    return addressResult.Data;
  }
}