using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class ProductCommentRepository : GenericRepository<ProductComment,EComDbContext>
{
    public ProductCommentRepository(EComDbContext context) : base(context)
    {
    }
}