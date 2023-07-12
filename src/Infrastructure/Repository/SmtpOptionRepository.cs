namespace ECom.Infrastructure.Repository;

public class SmtpOptionRepository : GenericRepository<SmtpOption, EComDbContext>
{
  public SmtpOptionRepository(EComDbContext context) : base(context) {
  }
}