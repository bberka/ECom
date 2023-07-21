using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ShowCaseRepository : GenericRepository<ShowCase, EComDbContext>
{
  public ShowCaseRepository(EComDbContext context) : base(context) {
  }
}