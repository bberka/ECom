using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class ImageRepository : GenericRepository<Image,EComDbContext>
{
    public ImageRepository(EComDbContext context) : base(context)
    {
    }
}