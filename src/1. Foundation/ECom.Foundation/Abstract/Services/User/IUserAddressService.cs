using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.User;

public interface IUserAddressService
{
  public Result UpdateAddress(Guid userId, Address address);
  public Result DeleteAddress(Guid userId, Guid id);
  public Result AddAddress(Guid userId, Request_Address_Add address);
  public Result<Address> GetAddress(Guid userId, Guid addressId);
}