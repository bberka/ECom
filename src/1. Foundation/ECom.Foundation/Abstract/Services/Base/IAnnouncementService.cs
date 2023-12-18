using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IAnnouncementService : ICacheService<List<Announcement>>
{
  List<Announcement> Get();
}