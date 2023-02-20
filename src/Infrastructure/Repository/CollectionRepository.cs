using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CollectionRepository : GenericRepository<Collection,EComDbContext>
{
    public CollectionRepository(EComDbContext context) : base(context)
    {
    }
}