namespace ECom.Infrastructure.Repository;

public class RoleRepository : GenericRepository<Role, EComDbContext>
{
  public RoleRepository(EComDbContext context) : base(context) {
  }
}