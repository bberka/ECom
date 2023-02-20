using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class EmailVerifyTokenRepository : GenericRepository<EmailVerifyToken,EComDbContext>
{
    public EmailVerifyTokenRepository(EComDbContext context) : base(context)
    {
    }
}