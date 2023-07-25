using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminAddressService  : IAddressService
{
  public List<Address> GetUserAddresses(Guid userId);
  public CustomResult<Address> GetAddress(Guid addressId);
}