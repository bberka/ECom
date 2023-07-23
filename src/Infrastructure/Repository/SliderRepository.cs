using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class SliderRepository : RepositoryBase<Slider>
{
  public SliderRepository(DbContext context) : base(context) {
  }
}