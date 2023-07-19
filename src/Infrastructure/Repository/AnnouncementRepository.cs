using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class AnnouncementRepository : GenericRepository<Announcement, EComDbContext>
{
  public AnnouncementRepository(EComDbContext context) : base(context) {
  }
}