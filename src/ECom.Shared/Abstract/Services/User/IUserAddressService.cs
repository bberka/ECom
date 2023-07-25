using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.User;

public interface IUserAddressService : IAddressService
{
  public CustomResult UpdateAddress(Guid userId, Address address);
  public CustomResult DeleteAddress(Guid userId, Guid id);
  public CustomResult AddAddress(Guid userId, Address address);
  public CustomResult<Address> GetAddress(Guid userId, Guid addressId);
}