namespace ECom.Infrastructure.Repository;

public class CargoOptionRepository : GenericRepository<CargoOption, EComDbContext>
{
  public CargoOptionRepository(EComDbContext context) : base(context) {
  }
}