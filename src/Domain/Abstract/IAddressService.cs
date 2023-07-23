using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IAddressService
{
  public List<Address> GetUserAddresses(Guid userId);
  public CustomResult UpdateAddress(Guid userId, Address address);
  public CustomResult DeleteAddress(Guid userId, Guid id);
  public CustomResult AddAddress(Guid userId, Address address);
  public CustomResult<Address> GetAddress(Guid userId, Guid addressId);
  public CustomResult<Address> GetAddress(Guid addressId);
}