using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class PasswordResetTokenRepository : GenericRepository<PasswordResetToken,EComDbContext>
{
    public PasswordResetTokenRepository(EComDbContext context) : base(context)
    {
    }
}