using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class PasswordResetTokenRepository : RepositoryBase<PasswordResetToken>
{
  public PasswordResetTokenRepository(DbContext context) : base(context) {
  }
}