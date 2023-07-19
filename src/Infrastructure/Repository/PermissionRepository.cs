using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class PermissionRepository : GenericRepository<Permission, EComDbContext>
{
  public PermissionRepository(EComDbContext context) : base(context) {
  }
}