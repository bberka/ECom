using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class PermissionRoleRepository : RepositoryBase<PermissionRole>
{
  public PermissionRoleRepository(DbContext context) : base(context) {
  }
}