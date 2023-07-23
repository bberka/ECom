using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductCommentRepository : RepositoryBase<ProductComment>
{
  public ProductCommentRepository(DbContext context) : base(context) {
  }
}