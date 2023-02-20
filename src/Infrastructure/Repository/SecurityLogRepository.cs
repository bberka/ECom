
namespace ECom.Infrastructure.Repository;

public class SecurityLogRepository : GenericRepository<SecurityLog, EComDbContext>
{
    public SecurityLogRepository(EComDbContext context) : base(context)
    {
    }
}
