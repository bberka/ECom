

using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class AddressRepository : RepositoryBase<Address>
{
  public AddressRepository(DbContext context) : base(context) {
  }
}