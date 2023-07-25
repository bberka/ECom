using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class UserRepository : RepositoryBase<User>
{
  public UserRepository(DbContext context) : base(context) {
  }
}