using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class AnnouncementRepository : GenericRepository<Announcement,EComDbContext>
{
    public AnnouncementRepository(EComDbContext context) : base(context)
    {
    }
}