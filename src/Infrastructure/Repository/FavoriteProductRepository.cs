using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class FavoriteProductRepository : RepositoryBase<FavoriteProduct>
{
  public FavoriteProductRepository(DbContext context) : base(context) {
  }
}