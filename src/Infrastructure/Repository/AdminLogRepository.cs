using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class AdminLogRepository : GenericRepository<AdminLog, EComDbContext>
{
  public AdminLogRepository(EComDbContext context) : base(context) {
  }
}