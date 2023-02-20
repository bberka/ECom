using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class PermissionRoleRepository : GenericRepository<PermissionRole,EComDbContext>
{
    public PermissionRoleRepository(EComDbContext context) : base(context)
    {
    }
}