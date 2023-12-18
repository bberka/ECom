using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IAddressService
{
  Result<List<Address>> GetUserAddresses(Guid userId);
  public Result<Address> GetAddress(Guid addressId);
}