namespace ECom.Business.Services.BaseServices;

public class AddressService : IAddressService
{
  private readonly IUnitOfWork _unitOfWork;

  public AddressService(
    IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result<List<Address>> GetUserAddresses(Guid userId) {
    var res = _unitOfWork.Addresses.Where(x => x.UserId == userId && !x.DeleteDate.HasValue).ToList();
    return res;
  }

  public Result<Address> GetAddress(Guid addressId) {
    ArgumentNullException.ThrowIfNull(addressId);
    var address = _unitOfWork.Addresses.Find(addressId);
    if (address is null || address.DeleteDate.HasValue)
      return DomResults.x_is_not_found("address");
    return address;
  }

  public Result<List<Address>> GetUserAddressList(Guid userId) {
    ArgumentNullException.ThrowIfNull(userId);
    var addressList = _unitOfWork.Users
                                 .Where(x => x.Id == userId && !x.DeleteDate.HasValue)
                                 .Include(x => x.Addresses)
                                 .SelectMany(x => x.Addresses)
                                 .ToList();
    return addressList;
  }
}