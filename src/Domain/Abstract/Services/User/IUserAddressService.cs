using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.User;

public interface IUserAddressService : IAddressService
{
  public CustomResult UpdateAddress(Guid userId, Address address);
  public CustomResult DeleteAddress(Guid userId, Guid id);
  public CustomResult AddAddress(Guid userId, Address address);
  public CustomResult<Address> GetAddress(Guid userId, Guid addressId);
}