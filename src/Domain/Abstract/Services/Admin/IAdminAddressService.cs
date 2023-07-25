using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminAddressService  : IAddressService
{
  public List<Address> GetUserAddresses(Guid userId);
  public CustomResult<Address> GetAddress(Guid addressId);
}