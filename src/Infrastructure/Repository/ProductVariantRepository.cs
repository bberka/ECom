using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;


public class ProductVariantRepository : GenericRepository<ProductVariant,EComDbContext>
{
    public ProductVariantRepository(EComDbContext context) : base(context)
    {
    }
}   
