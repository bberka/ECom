using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class SupplierRepository : GenericRepository<Supplier, EComDbContext>
{
  public SupplierRepository(EComDbContext context) : base(context) {
  }
}