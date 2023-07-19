using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class PasswordResetTokenRepository : GenericRepository<PasswordResetToken, EComDbContext>
{
  public PasswordResetTokenRepository(EComDbContext context) : base(context) {
  }
}