using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class LocalizationStringRepository : GenericRepository<LocalizationString, EComDbContext>
{
  public LocalizationStringRepository(EComDbContext context) : base(context) {
  }
}
