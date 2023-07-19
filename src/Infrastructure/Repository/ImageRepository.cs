using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ImageRepository : GenericRepository<Image, EComDbContext>
{
  public ImageRepository(EComDbContext context) : base(context) {
  }
}