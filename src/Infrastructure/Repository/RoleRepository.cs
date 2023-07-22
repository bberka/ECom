using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class RoleRepository : RepositoryBase<Role>
{
  public RoleRepository(DbContext context) : base(context) {
  }
}