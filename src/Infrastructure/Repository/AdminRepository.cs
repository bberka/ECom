using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class AdminRepository : GenericRepository<Admin,EComDbContext>
{
    public AdminRepository(EComDbContext context) : base(context)
    {
    }
}