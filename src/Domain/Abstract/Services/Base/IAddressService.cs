using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Base;

public interface IAddressService
{
  List<Address> GetUserAddresses(Guid userId);
}