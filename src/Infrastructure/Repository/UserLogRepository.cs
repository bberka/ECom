namespace ECom.Infrastructure.Repository;

public class UserLogRepository : GenericRepository<UserLog, EComDbContext>
{
  public UserLogRepository(EComDbContext context) : base(context) {
  }
}