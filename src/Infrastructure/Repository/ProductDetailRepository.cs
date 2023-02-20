using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class ProductDetailRepository : GenericRepository<ProductDetail,EComDbContext>
{
    public ProductDetailRepository(EComDbContext context) : base(context)
    {
    }
}