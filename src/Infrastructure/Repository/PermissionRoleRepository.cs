using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class PermissionRoleRepository : GenericRepository<PermissionRole, EComDbContext>
{
  public PermissionRoleRepository(EComDbContext context) : base(context) {
  }
}