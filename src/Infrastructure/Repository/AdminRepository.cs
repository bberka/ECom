using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class AdminRepository : GenericRepository<Admin, EComDbContext>
{
  public AdminRepository(EComDbContext context) : base(context) {
  }
}