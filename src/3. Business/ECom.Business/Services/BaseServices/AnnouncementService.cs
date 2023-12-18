namespace ECom.Business.Services.BaseServices;

public class AnnouncementService : IAnnouncementService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public AnnouncementService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public List<Announcement> Get() {
    return _unitOfWork.Announcements.Where(x => x.ExpireDate > DateTime.Now).ToList();
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.Announcement);
  }


  public void SetCacheValue(List<Announcement> data) {
    _memoryCache.Set(CacheKeys.Announcement, data, TimeSpan.FromMinutes(CacheTimes.Announcement));
  }

  public List<Announcement>? GetFromCache() {
    return _memoryCache.Get<List<Announcement>>(CacheKeys.Announcement);
  }

  public List<Announcement> GetFromDb() {
    var data = _unitOfWork.Announcements.Where(x => x.ExpireDate > DateTime.Now).ToList();
    if (data is null) return new List<Announcement>();
    return data;
  }
}