

namespace ECom.Infrastructure.Services
{
	public interface IAdminLogService : IEfEntityRepository<AdminLog>
	{
	}
	public class AdminLogService : EfEntityRepositoryBase<AdminLog, EComDbContext>, IAdminLogService
	{

	}

}
