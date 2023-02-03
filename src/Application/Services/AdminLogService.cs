

namespace ECom.Application.Services
{
	public interface IAdminLogService : IEfEntityRepository<AdminLog>
	{
	}
	public class AdminLogService : EfEntityRepositoryBase<AdminLog, EComDbContext>, IAdminLogService
	{

	}

}
