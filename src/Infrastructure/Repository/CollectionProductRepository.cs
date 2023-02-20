using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CollectionProductRepository : GenericRepository<CollectionProduct,EComDbContext>
{
    public CollectionProductRepository(EComDbContext context) : base(context)
    {
    }
}