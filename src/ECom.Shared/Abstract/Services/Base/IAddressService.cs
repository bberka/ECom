using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Base;

public interface IAddressService
{
  List<Address> GetUserAddresses(Guid userId);
}