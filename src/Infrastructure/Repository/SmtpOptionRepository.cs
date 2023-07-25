using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class SmtpOptionRepository : RepositoryBase<SmtpOption>
{
  public SmtpOptionRepository(DbContext context) : base(context) {
  }
}