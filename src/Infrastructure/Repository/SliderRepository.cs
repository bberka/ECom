using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class SliderRepository : GenericRepository<Slider, EComDbContext>
{
  public SliderRepository(EComDbContext context) : base(context) {
  }
}