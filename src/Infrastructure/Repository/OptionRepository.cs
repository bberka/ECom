using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class OptionRepository : RepositoryBase<Option>
{
  public OptionRepository(DbContext context) : base(context) {
  }
}