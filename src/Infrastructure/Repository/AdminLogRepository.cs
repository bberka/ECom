using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class AdminLogRepository : RepositoryBase<AdminLog>
{
  public AdminLogRepository(DbContext context) : base(context) {
  }
}