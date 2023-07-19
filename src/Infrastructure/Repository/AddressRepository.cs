using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class AddressRepository : GenericRepository<Address, EComDbContext>
{
  public AddressRepository(EComDbContext context) : base(context) {
  }
}