using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class AdminLogRepository : GenericRepository<AdminLog,EComDbContext>
{
    public AdminLogRepository(EComDbContext context) : base(context)
    {
    }
}