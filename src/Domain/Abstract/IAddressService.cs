namespace ECom.Domain.Abstract;

public interface IAddressService
{
  public List<Address> GetUserAddresses(int userId);
  public CustomResult UpdateAddress(int userId, Address address);
  public CustomResult DeleteAddress(int userId, int id);
  public CustomResult AddAddress(int userId, Address address);
  public CustomResult<Address> GetAddress(int userId, int addressId);
  public CustomResult<Address> GetAddress(int addressId);
}